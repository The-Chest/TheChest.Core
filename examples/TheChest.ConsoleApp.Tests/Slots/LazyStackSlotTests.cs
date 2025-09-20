using TheChest.Core.Tests.Slots;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class LazyStackSlotTests : ILazyStackSlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new LazyStackSlotFactory<LazyStackSlot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };

        public LazyStackSlotTests(
            ILazyStackSlotFactory<Item> slotFactory, 
            ISlotItemFactory<Item> itemFactory
        ) : base(slotFactory, itemFactory) { }
    }
}
