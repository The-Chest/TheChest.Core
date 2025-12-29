using System.Reflection;
using TheChest.Core.Tests.Attributes;
using TheChest.Core.Tests.Extensions;

namespace TheChest.Core.Tests.Configurations.DependencyInjection
{
    public sealed class DIContainer
    {
        private readonly DIRegistry registry;

        public DIContainer() 
        {
            this.registry = new DIRegistry();
        }

        public DIContainer Register<TService, TImpl>() where TImpl : TService
        {
            this.registry.Register(typeof(TService), typeof(TImpl));
            return this;
        }

        public DIContainer Register(Type serviceType, Type implementationType)
        {
            this.registry.Register(serviceType, implementationType);
            return this;
        }

        public DIContainer Register<TService>(Func<DIContainer, TService> factory)
        {
            this.registry.Register(factory);
            return this;
        }

        public DIContainer Register<TService>(TService instance)
        {
            this.registry.Register(instance);
            return this;
        }

        public bool IsRegistered<TService>()
        {
            return this.registry.IsRegistered<TService>();
        }

        public T Resolve<T>() => (T)this.Resolve(typeof(T));

        public object Resolve(Type serviceType)
        {
            if (!this.registry.TryGetRegistration(serviceType, out var reg))
                throw new InvalidOperationException($"Service {serviceType} is not registered");

            if (reg == null)
                throw new InvalidOperationException("Registration is null");

            if (reg.Factory != null)
                return reg.Factory(this);

            var implType = reg.ImplementationType ?? serviceType;
            var constructor = implType.GetSmallerConstructor() 
                ?? throw new InvalidOperationException($"No public constructor found for {implType.FullName}");

            var args = constructor.GetParameters();
            var instance = default(object);

            if (args.Length == 0)
                instance = Activator.CreateInstance(implType)!;

            var parameters = new object[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                parameters[i] = this.Resolve(args[i].ParameterType);
            }

            instance ??= constructor.Invoke(parameters)!;

            if ((implType.Name.Contains("Factory")) && (implType.Namespace?.EndsWith("Factories") ?? false))
            {
                var method = typeof(ReflectionExceptionHandleProxy<>)
                    .MakeGenericType(serviceType)
                    .GetMethod("Create", BindingFlags.Public | BindingFlags.Static);
                return method!.Invoke(constructor, new object[] { instance })!;
            }
            
            return instance;
        }
    }
}
