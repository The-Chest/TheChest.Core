using TheChest.Core.Tests.Slots;

namespace TheChest.ConsoleApp.Tests.Slots
{
    [TestFixtureSource(nameof(SlotFixtureArgs))]
    public class StackSlotTests : IStackSlotTests<Item>
    {
        static readonly object[] SlotFixtureArgs = {
            new object[] {
                new StackSlotFactory<StackSlot, Item>(),
                new SlotItemFactory<Item>(),
            },
            new object[] {
                new LazyStackSlotFactory<LazyStackSlot, Item>(),
                new SlotItemFactory<Item>(),
            }
        };

        public StackSlotTests(IStackSlotFactory<Item> slotFactory, ISlotItemFactory<Item> itemFactory) : base(slotFactory, itemFactory)
        {
        }
    }
}
