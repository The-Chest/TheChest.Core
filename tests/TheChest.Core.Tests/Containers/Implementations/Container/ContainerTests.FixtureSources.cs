using TheChest.Core.Slots;
using TheChest.Core.Containers;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Slots.Implementations.Factories;
using TheChest.Core.Tests.Containers.Implementations.Factories;

namespace TheChest.Core.Tests.Containers.Implementations
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class ContainerTests : ContainerTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new ContainerFactory<Container<TestItem>, TestItem>(
                    new SlotFactory<Slot<TestItem>, TestItem>()
                ),
                new ItemFactory<TestItem>()
            }
        };

        public ContainerTests(IContainerFactory<TestItem> containerFactory, IItemFactory<TestItem> itemFactory) : 
            base(containerFactory, itemFactory)
        {
        }
    }
}
