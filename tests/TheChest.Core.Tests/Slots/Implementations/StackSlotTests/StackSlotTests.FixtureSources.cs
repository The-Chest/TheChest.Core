using TheChest.Core.Slots;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Implementations.Factories;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class StackSlotTests : StackSlotTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new StackSlotFactory<StackSlot<TestItem>, TestItem>(),
                new ItemFactory<TestItem>()
            }
        };

        public StackSlotTests(IStackSlotFactory<TestItem> slotFactory, IItemFactory<TestItem> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
