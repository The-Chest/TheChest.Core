namespace TheChest.Core.Tests.Slots.Implementations
{
    public abstract partial class SlotTests<T> : ISlotTests<T>
    {
        protected SlotTests(ISlotFactory<T> slotFactory, IItemFactory<T> itemFactory)
            : base(slotFactory, itemFactory)
        {
        }
    }
}
