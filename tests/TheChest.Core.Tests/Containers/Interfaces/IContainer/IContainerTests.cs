using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Containers.Interfaces
{
    public abstract partial class IContainerTests<T> : BaseTest<T>
    {
        protected readonly IContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected IContainerTests(Action<DIContainer> configure) : base(configure)
        {
            this.containerFactory = this.configurations.Resolve<IContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}
