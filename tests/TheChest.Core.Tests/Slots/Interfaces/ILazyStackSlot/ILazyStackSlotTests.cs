namespace TheChest.Core.Tests.Slots.Interfaces
{
    public abstract partial class ILazyStackSlotTests<T>
    {
        protected readonly ILazyStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;
        protected Random random;

        protected ILazyStackSlotTests(
            ILazyStackSlotFactory<T> slotFactory, 
            IItemFactory<T> itemFactory
        )
        {
            this.slotFactory = slotFactory;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
            random = new Random();
        }
    }
}
