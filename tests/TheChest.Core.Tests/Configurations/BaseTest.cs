using TheChest.Core.Tests.Configurations.DependencyInjection;
using TheChest.Core.Tests.Items;

namespace TheChest.Core.Tests.Configurations
{
    public abstract class BaseTest<T>
    {
        protected readonly DIContainer configurations;
        protected readonly Random random;

        protected BaseTest(Action<DIContainer> configure)
        {
            this.configurations = new DIContainer();

            configure(this.configurations);

            if (!this.configurations.IsRegistered<IItemFactory<T>>())
                this.configurations.Register<IItemFactory<T>, ItemFactory<T>>();
            
            this.random = new Random();
        }
    }
}
