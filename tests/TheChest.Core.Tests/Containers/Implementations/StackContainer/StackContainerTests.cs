using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Containers.Interfaces.Factories;

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
