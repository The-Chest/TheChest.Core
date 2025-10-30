using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    public partial class StackSlotTests<T> : IStackSlotTests<T>
    {
        public StackSlotTests(IStackSlotFactory<T> slotFactory, IItemFactory<T> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
