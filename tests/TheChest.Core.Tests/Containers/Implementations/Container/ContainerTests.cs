using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Containers.Interfaces.Factories;

namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class ContainerTests<T> : IContainerTests<T>
    {
        public ContainerTests(IContainerFactory<T> containerFactory, ISlotItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
