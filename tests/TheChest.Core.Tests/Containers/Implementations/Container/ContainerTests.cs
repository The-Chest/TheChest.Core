using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Containers.Interfaces.Factories;
using TheChest.Core.Tests.Items.Interfaces;

namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class ContainerTests<T> : IContainerTests<T>
    {
        public ContainerTests(IContainerFactory<T> containerFactory, IItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
