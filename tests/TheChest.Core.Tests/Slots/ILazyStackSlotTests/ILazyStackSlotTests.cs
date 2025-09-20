namespace TheChest.Core.Tests.Slots
{
    public abstract partial class ILazyStackSlotTests<T>
    {
        protected readonly ILazyStackSlotFactory<T> slotFactory;
        protected readonly ISlotItemFactory<T> itemFactory;
        protected Random random;

        protected ILazyStackSlotTests(
            ILazyStackSlotFactory<T> slotFactory, 
            ISlotItemFactory<T> itemFactory
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
