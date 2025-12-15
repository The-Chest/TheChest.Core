using TheChest.Core.Tests.Configurations;

namespace TheChest.Core.Tests.Containers.Interfaces
{
    public abstract partial class ILazyStackContainerTests<T> : BaseTest<T>
    {
        protected readonly ILazyStackContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected const int MIN_STACK_SIZE_TEST = 10;
        protected const int MAX_STACK_SIZE_TEST = 20;

        protected ILazyStackContainerTests(Action<DIContainer> configure) : base(configure)
        {
            this.containerFactory = this.configurations.Resolve<ILazyStackContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}
