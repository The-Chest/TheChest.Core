namespace TheChest.Core.Tests.Containers
{
    public abstract partial class IContainerTests<T>
    {
        [Test]
        public void IsFull_EmptySlots_ReturnsFalse() 
        {
            var container = this.containerFactory.EmptyContainer();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemsContainer(
                randomSize, 
                this.itemFactory.CreateMany(randomSize - 1)
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemContainer(
                randomSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.FullContainer(
                randomSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.True);
        }
    }
}
