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
