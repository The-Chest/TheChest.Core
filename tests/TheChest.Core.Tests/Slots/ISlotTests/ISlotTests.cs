namespace TheChest.Core.Tests.Slots
{
    public abstract partial class ISlotTests<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly ISlotItemFactory<T> itemFactory;

        protected ISlotTests(ISlotFactory<T> slotFactory, ISlotItemFactory<T> itemFactory)
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }
    }
}
