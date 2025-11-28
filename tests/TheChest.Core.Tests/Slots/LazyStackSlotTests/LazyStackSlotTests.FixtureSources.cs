using TheChest.Core.Slots;
using TheChest.Core.Tests.Items;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Slots.Implementations;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    [TestFixtureSource(nameof(FixtureArgs))]
    internal class LazyStackSlotTests : LazyStackSlotTests<TestItem>
    {
        static readonly object[] FixtureArgs =
        {
            new object[]
            {
                new LazyStackSlotFactory<LazyStackSlot<TestItem>, TestItem>(),
                new ItemFactory<TestItem>()
            }
        };
        public LazyStackSlotTests(ILazyStackSlotFactory<TestItem> slotFactory, IItemFactory<TestItem> itemFactory) :
            base(slotFactory, itemFactory)
        {
        }
    }
}
