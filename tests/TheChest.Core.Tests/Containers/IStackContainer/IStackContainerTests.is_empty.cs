namespace TheChest.Core.Tests.Containers
{
    public partial class IStackContainerTests<T>
    {
        [Test]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.ShuffledItemsContainer(randomSize, randomStackSize, this.itemFactory.CreateDefault());
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.FullContainer(randomSize, randomStackSize, this.itemFactory.CreateDefault());

            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
