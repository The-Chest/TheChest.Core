using System.Collections.Concurrent;
using System.Reflection;

namespace TheChest.Core.Tests.Configurations
{
    internal enum Lifetime
    {
        Transient,
        Singleton,
        Scoped
    }

    internal class Registration
    {
        public Lifetime Lifetime { get; }
        public Type ServiceType { get; }
        public Type? ImplementationType { get; }
        public Func<DIContainer, object>? Factory { get; }

        public Registration(Type serviceType, Type implType, Lifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implType;
            Lifetime = lifetime;
        }

        public Registration(Type serviceType, Func<DIContainer, object> factory, Lifetime lifetime)
        {
            ServiceType = serviceType;
            Factory = factory;
            Lifetime = lifetime;
        }
    }

    public sealed class DIContainer : IDisposable
    {
        private readonly Dictionary<Type, Registration> _registrations = new();
        private readonly List<Registration> _openGenericRegistrations = new();
        private readonly ConcurrentDictionary<Type, object> _singletons = new();
        private bool _disposed;
        private readonly object _singletonLock = new();

        [ThreadStatic] 
        private static Stack<Type>? _buildStack;

        public DIContainer()
        {
        }

        #region Registration API

        public void Register<TService, TImpl>()
            where TImpl : TService
        {
            Register(typeof(TService), typeof(TImpl));
        }

        public void Register(Type serviceType, Type implementationType)
        {
            if (serviceType.IsGenericTypeDefinition || implementationType.IsGenericTypeDefinition)
            {
                _openGenericRegistrations.Add(new Registration(serviceType, implementationType, Lifetime.Transient));
                return;
            }

            _registrations[serviceType] = new Registration(serviceType, implementationType, Lifetime.Transient);
        }

        public void Register<TService>(Func<DIContainer, object> factory)
        {
            _registrations[typeof(TService)] = new Registration(typeof(TService), factory, Lifetime.Transient);
        }

        public void Register<TService>(TService instance)
        {
            if (instance is null) 
                throw new ArgumentNullException(nameof(instance));

            var t = typeof(TService);
            _registrations[t] = new Registration(t, c => instance, Lifetime.Singleton);
            _singletons[t] = instance;
        }

        #endregion

        #region Resolve API

        public T Resolve<T>() => (T)Resolve(typeof(T));

        public object Resolve(Type serviceType)
        {
            if (_disposed) 
                throw new ObjectDisposedException(nameof(DIContainer));

            _buildStack ??= new Stack<Type>();

            if (_buildStack.Contains(serviceType))
                throw new InvalidOperationException("Circular dependency detected: " + string.Join(" -> ", _buildStack.Reverse().Select(t => t.Name)) + " -> " + serviceType.Name);

            if (TryGetRegistration(serviceType, out var reg))
                return ResolveRegistration(reg!, serviceType);

            if (!serviceType.IsAbstract && !serviceType.IsInterface)
                return ConstructType(serviceType);

            throw new InvalidOperationException($"Service {serviceType} is not registered");
        }

        private bool TryGetRegistration(Type serviceType, out Registration? registration)
        {
            if (_registrations.TryGetValue(serviceType, out registration))
                return true;

            if (serviceType.IsGenericType)
            {
                var genDef = serviceType.GetGenericTypeDefinition();
                var match = _openGenericRegistrations.FirstOrDefault(r => r.ServiceType == genDef);
                if (match != null)
                {
                    if (match.ImplementationType == null)
                        throw new InvalidOperationException("Open generic registration has no implementation type");

                    var implType = match.ImplementationType.MakeGenericType(serviceType.GetGenericArguments());
                    registration = new Registration(serviceType, implType, match.Lifetime);
                    return true;
                }
            }

            registration = null;
            return false;
        }

        private object ResolveRegistration(Registration reg, Type requestedServiceType)
        {
            if (reg.Factory != null)
                return ManageLifetimeForFactory(reg, requestedServiceType);

            var implType = reg.ImplementationType ?? requestedServiceType;
            return reg.Lifetime switch
            {
                Lifetime.Transient => ConstructType(implType),
                Lifetime.Singleton => GetOrCreateSingleton(requestedServiceType, () => ConstructType(implType)),
                Lifetime.Scoped => GetOrCreateScoped(requestedServiceType, () => ConstructType(implType)),
                _ => throw new NotSupportedException("Unknown lifetime"),
            };
        }

        private object ManageLifetimeForFactory(Registration reg, Type requestedServiceType)
        {
            if(reg.Factory == null)
                throw new InvalidOperationException("Factory is null in registration");

            return reg.Lifetime switch
            {
                Lifetime.Transient => reg.Factory(this),
                Lifetime.Singleton => GetOrCreateSingleton(requestedServiceType, () => reg.Factory(this)),
                Lifetime.Scoped => GetOrCreateScoped(requestedServiceType, () => reg.Factory(this)),
                _ => throw new NotSupportedException("Unknown lifetime"),
            };
        }

        private object GetOrCreateSingleton(Type serviceType, Func<object> creator)
        {
            if (_singletons.TryGetValue(serviceType, out var existing))
                return existing;

            lock (_singletonLock)
            {
                if (_singletons.TryGetValue(serviceType, out existing)) return existing;
                var created = creator();
                _singletons[serviceType] = created;
                return created;
            }
        }

        private object GetOrCreateScoped(Type serviceType, Func<object> creator)
        {
            return _singletons.GetOrAdd(serviceType, _ => creator());
        }

        private object ConstructType(Type implType)
        {
            _buildStack ??= new Stack<Type>();
            _buildStack.Push(implType);
            try
            {
                var ctors = implType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
                var ctor = ctors.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault() 
                    ?? throw new InvalidOperationException("No public constructor found for " + implType.FullName);
                var parameters = ctor.GetParameters();
                if (parameters.Length == 0)
                    return Activator.CreateInstance(implType)!;

                var args = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = Resolve(parameters[i].ParameterType);
                }

                return ctor.Invoke(args);
            }
            finally
            {
                _buildStack.Pop();
            }
        }

        #endregion

        public void Dispose()
        {
            if (_disposed) 
                return;
            _disposed = true;

            foreach (var kv in _singletons)
            {
                if (kv.Value is IDisposable d) 
                    d.Dispose();
            }
        }
    }
}
