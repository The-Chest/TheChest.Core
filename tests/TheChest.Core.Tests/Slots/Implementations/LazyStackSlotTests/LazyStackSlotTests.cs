using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    public partial class LazyStackSlotTests<T> : ILazyStackSlotTests<T>
    {
        public LazyStackSlotTests(ILazyStackSlotFactory<T> slotFactory, IItemFactory<T> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
