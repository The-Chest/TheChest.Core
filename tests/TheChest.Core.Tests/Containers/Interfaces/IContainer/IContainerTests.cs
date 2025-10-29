namespace TheChest.Core.Tests.Containers.Interfaces
{
    public abstract partial class IContainerTests<T>
    {
        protected Random random;
        protected readonly IContainerFactory<T> containerFactory;
        protected readonly ISlotItemFactory<T> itemFactory;

        protected const int MIN_SIZE_TEST = 10;
        protected const int MAX_SIZE_TEST = 20;

        protected IContainerTests(IContainerFactory<T> containerFactory, ISlotItemFactory<T> itemFactory)
        {
            this.containerFactory = containerFactory;
            this.itemFactory = itemFactory;
        }

        [SetUp]
        public void Setup()
        {
            this.random = new Random();
        }
    }
}
