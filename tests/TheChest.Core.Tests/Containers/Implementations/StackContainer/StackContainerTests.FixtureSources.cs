using TheChest.Core.Slots;
using TheChest.Core.Containers;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Containers.Factories;

namespace TheChest.Core.Tests.Containers.Implementations
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class StackContainerTests : StackContainerTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new StackContainerFactory<StackContainer<TestItem>, TestItem>(
                    new StackSlotFactory<StackSlot<TestItem>, TestItem>()
                ),
                new ItemFactory<TestItem>()
            }
        };

        public StackContainerTests(IStackContainerFactory<TestItem> containerFactory, IItemFactory<TestItem> itemFactory) :
            base(containerFactory, itemFactory)
        {
        }
    }
}
