using TheChest.Core.Slots;
using TheChest.Core.Containers;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Slots.Implementations.Factories;
using TheChest.Core.Tests.Containers.Implementations.Factories;

namespace TheChest.Core.Tests.Containers.Implementations
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class LazyStackContainerTests : LazyStackContainerTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new LazyStackContainerFactory<LazyStackContainer<TestItem>,TestItem>(
                    new LazyStackSlotFactory<LazyStackSlot<TestItem>, TestItem>()
                ),
                new ItemFactory<TestItem>()
            }
        };

        public LazyStackContainerTests(ILazyStackContainerFactory<TestItem> containerFactory, IItemFactory<TestItem> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
