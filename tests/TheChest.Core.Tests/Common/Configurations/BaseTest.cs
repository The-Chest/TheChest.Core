using TheChest.Core.Tests.Common.Configurations.DependencyInjection;
using TheChest.Core.Tests.Common.Items;
using TheChest.Core.Tests.Common.Items.Interfaces;

namespace TheChest.Core.Tests.Common.Configurations
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
