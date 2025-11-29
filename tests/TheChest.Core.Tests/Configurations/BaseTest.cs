using TheChest.Core.Tests.Items;

namespace TheChest.Core.Tests.Configurations
{
    public abstract class BaseTest<T>
    {
        protected readonly DIContainer container;
        protected readonly Random random;

        protected BaseTest(Action<DIContainer> configure)
        {
            this.container = new DIContainer();

            configure(this.container);

            if (!this.container.IsRegistered<IItemFactory<T>>())
                this.container.Register<IItemFactory<T>, ItemFactory<T>>();
            
            this.random = new Random();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.container.Dispose();
        }
    }
}
