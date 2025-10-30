using TheChest.Core.Tests.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class LazyStackContainerTests<T> : ILazyStackContainerTests<T>
    {
        public LazyStackContainerTests(ILazyStackContainerFactory<T> containerFactory, ISlotItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
