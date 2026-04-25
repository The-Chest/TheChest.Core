namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class IContainerTests<T>
    {
        [Test]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var container = this.containerFactory.Empty();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.WithItemShuffled(randomSize, item);
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(randomSize, item);
            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
