namespace TheChest.Core.Tests.Configurations.DependencyInjection
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

    internal class DIRegistry
    {
        private readonly Dictionary<Type, Registration> registrations;
        private readonly List<Registration> openGenericRegistrations;

        public DIRegistry()
        {
            registrations = new Dictionary<Type, Registration>();
            openGenericRegistrations = new List<Registration>();
        }

        public void Register<TService, TImpl>() where TImpl : TService
        {
            this.Register(typeof(TService), typeof(TImpl));
        }

        public void Register(Type serviceType, Type implementationType)
        {
            var registration = new Registration(serviceType, implementationType);

            if (serviceType.IsGenericTypeDefinition || implementationType.IsGenericTypeDefinition)
                openGenericRegistrations.Add(registration);
            else
                registrations[serviceType] = registration;
        }

        public void Register<TService>(Func<DIContainer, object> factory)
        {
            registrations[typeof(TService)] = new Registration(typeof(TService), factory);
        }

        public void Register<TService>(TService instance)
        {
            if (instance is null)
                throw new ArgumentNullException(nameof(instance));

            var serviceType = typeof(TService);
            registrations[serviceType] = new Registration(serviceType, c => instance);
        }

        public bool IsRegistered<TService>()
        {
            return this.TryGetRegistration(typeof(TService), out var _);
        }

        public bool TryGetRegistration(Type serviceType, out Registration? registration)
        {
            if (registrations.TryGetValue(serviceType, out registration))
                return true;

            if (serviceType.IsGenericType)
            {
                var genDef = serviceType.GetGenericTypeDefinition();
                var match = openGenericRegistrations.FirstOrDefault(r => r.ServiceType == genDef);
                if (match != null)
                {
                    if (match.ImplementationType == null)
                        throw new InvalidOperationException("Open generic registration has no implementation type");

                    var implType = match.ImplementationType.MakeGenericType(serviceType.GetGenericArguments());
                    registration = new Registration(serviceType, implType);
                    return true;
                }
            }

            registration = null;
            return false;
        }
    }
}
