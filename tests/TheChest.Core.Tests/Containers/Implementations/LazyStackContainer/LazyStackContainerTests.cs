using TheChest.Core.Tests.Containers.Interfaces;
using TheChest.Core.Tests.Containers.Interfaces.Factories;
using TheChest.Core.Tests.Items.Interfaces;

namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class LazyStackContainerTests<T> : ILazyStackContainerTests<T>
    {
        public LazyStackContainerTests(ILazyStackContainerFactory<T> containerFactory, IItemFactory<T> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
