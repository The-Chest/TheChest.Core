namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test(Description = "IsEmpty property of the container when all slots are empty.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test(Description = "IsEmpty property of the container when some slots are empty.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();

            var container = this.containerFactory.WithItemShuffled(size, item);

            Assert.That(container.IsEmpty, Is.False);
        }

        [Test(Description = "IsEmpty property of the container when all slots are full.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(size, item);

            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
