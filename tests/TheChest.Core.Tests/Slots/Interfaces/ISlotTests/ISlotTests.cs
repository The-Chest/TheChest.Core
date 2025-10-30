using TheChest.Core.Tests.Items.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.Factories;

namespace TheChest.Core.Tests.Slots
{
    public abstract partial class ISlotTests<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected ISlotTests(ISlotFactory<T> slotFactory, IItemFactory<T> itemFactory)
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }
    }
}
