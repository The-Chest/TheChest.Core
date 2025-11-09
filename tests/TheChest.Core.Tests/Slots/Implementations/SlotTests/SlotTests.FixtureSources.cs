using TheChest.Core.Slots;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Slots.Implementations.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class SlotTests : SlotTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new SlotFactory<Slot<TestItem>, TestItem>(),
                new ItemFactory<TestItem>()
            }
        };

        public SlotTests(ISlotFactory<TestItem> slotFactory, IItemFactory<TestItem> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
