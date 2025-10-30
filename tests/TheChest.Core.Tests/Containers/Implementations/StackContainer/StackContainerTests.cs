using TheChest.Core.Tests.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class StackContainerTests<T> : IStackContainerTests<T>
    {
        public StackContainerTests(IStackContainerFactory<T> containerFactory, ISlotItemFactory<T> itemFactory) :
            base(containerFactory, itemFactory)
        {
        }
    }
}
