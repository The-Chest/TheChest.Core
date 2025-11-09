namespace TheChest.Core.Tests.Slots.Implementations
{
    public abstract partial class StackSlotTests<T> : IStackSlotTests<T>
    {
        protected StackSlotTests(IStackSlotFactory<T> slotFactory, IItemFactory<T> itemFactory) : 
            base(slotFactory, itemFactory)
        {
        }
    }
}
