using TheChest.Core.Tests.Configurations;
using TheChest.Core.Tests.Configurations.DependencyInjection;

namespace TheChest.Core.Tests.Containers.Interfaces
{
    public abstract partial class IStackContainerTests<T> : BaseTest<T>
    {
        protected readonly IStackContainerFactory<T> containerFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected const int MIN_STACK_SIZE_TEST = 10;
        protected const int MAX_STACK_SIZE_TEST = 20;

        protected IStackContainerTests(Action<DIContainer> configure) : base(configure)
        {
            this.containerFactory = this.configurations.Resolve<IStackContainerFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}
