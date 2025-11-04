using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots.Implementations
{
    public abstract partial class LazyStackSlotTests<T> : ILazyStackSlotTests<T>
    {
        protected LazyStackSlotTests(ILazyStackSlotFactory<T> slotFactory, IItemFactory<T> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
