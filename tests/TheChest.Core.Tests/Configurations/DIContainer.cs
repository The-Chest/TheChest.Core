using System.Reflection;
using System.Linq;

namespace TheChest.Core.Tests.Configurations
{
    internal class Registration
    {
        public Type ServiceType { get; }
        public Type? ImplementationType { get; }
        public Func<DIContainer, object>? Factory { get; }

        public Registration(Type serviceType, Type implType)
        {
            ServiceType = serviceType;
            ImplementationType = implType;
        }

        public Registration(Type serviceType, Func<DIContainer, object> factory)
        {
            ServiceType = serviceType;
            Factory = factory;
        }
    }

    public sealed class DIContainer : IDisposable
    {
        private bool disposed;

        private readonly Dictionary<Type, Registration> registrations;
        private readonly List<Registration> openGenericRegistrations;

        public DIContainer() 
        {
            this.registrations = new Dictionary<Type, Registration>();
            this.openGenericRegistrations = new List<Registration>();
        }

        public DIContainer Register<TService, TImpl>() where TImpl : TService
        {
            return this.Register(typeof(TService), typeof(TImpl));
        }

        public DIContainer Register(Type serviceType, Type implementationType)
        {
            var registration = new Registration(serviceType, implementationType);

            if (serviceType.IsGenericTypeDefinition || implementationType.IsGenericTypeDefinition)
            {
                this.openGenericRegistrations.Add(registration);
            }
            else
            {
                this.registrations[serviceType] = registration;
            }

            return this;
        }

        public DIContainer Register<TService>(Func<DIContainer, object> factory)
        {
            this.registrations[typeof(TService)] = new Registration(typeof(TService), factory);
            return this;
        }

        public DIContainer Register<TService>(TService instance)
        {
            if (instance is null) 
                throw new ArgumentNullException(nameof(instance));

            var serviceType = typeof(TService);
            this.registrations[serviceType] = new Registration(serviceType, c => instance);

            return this;
        }

        public bool IsRegistered<TService>()
        {
            return this.TryGetRegistration(typeof(TService), out var _);
        }

        public T Resolve<T>() => (T)Resolve(typeof(T));

        public object Resolve(Type serviceType)
        {
            if (disposed) 
                throw new ObjectDisposedException(nameof(DIContainer));

            if (TryGetRegistration(serviceType, out var reg))
            {
                if (reg == null)
                    throw new InvalidOperationException("Registration is null");

                if (reg.Factory != null)
                    return reg.Factory(this);

                var implType = reg.ImplementationType ?? serviceType;
                return this.ConstructType(implType);
            }

            if (!serviceType.IsAbstract && !serviceType.IsInterface)
                return ConstructType(serviceType);

            throw new InvalidOperationException($"Service {serviceType} is not registered");
        }

        private bool TryGetRegistration(Type serviceType, out Registration? registration)
        {
            if (this.registrations.TryGetValue(serviceType, out registration))
                return true;

            if (serviceType.IsGenericType)
            {
                var genDef = serviceType.GetGenericTypeDefinition();
                var match = this.openGenericRegistrations
                    .FirstOrDefault(r => r.ServiceType == genDef);
                if (match != null)
                {
                    if (match.ImplementationType == null)
                        throw new InvalidOperationException("Open generic registration has no implementation type");

                    var implType = match.ImplementationType
                        .MakeGenericType(serviceType.GetGenericArguments());
                    registration = new Registration(serviceType, implType);
                    return true;
                }
            }

            registration = null;
            return false;
        }

        private object ConstructType(Type implType)
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

        public void Dispose()
        {
            if (disposed) 
                return;
            disposed = true;

            foreach (var d in this.registrations.Values.OfType<IDisposable>())
            {
                d.Dispose();
            }
        }
    }
}
