namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class IContainerTests<T>
    {
        [Test]
        public void IsFull_EmptySlots_ReturnsFalse() 
        {
            var container = this.containerFactory.Empty();

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(randomSize - 1);

            var container = this.containerFactory.WithItemsShuffled(randomSize, items);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);

            var container = this.containerFactory.WithShuffledItem(randomSize, item);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);

            var container = this.containerFactory.Full(randomSize, item);

            Assert.That(container.IsFull, Is.True);
        }
    }
}
