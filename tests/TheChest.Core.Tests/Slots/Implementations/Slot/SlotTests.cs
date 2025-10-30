using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    public partial class SlotTests<T> : ISlotTests<T>
    {
        public SlotTests(ISlotFactory<T> slotFactory, IItemFactory<T> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
