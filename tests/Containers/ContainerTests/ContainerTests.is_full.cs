namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test(Description = "IsFull property of the container when it has empty slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_EmptySlots_ReturnsFalse()
        {
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);

            Assert.That(container.IsFull, Is.False);
        }

        [Test(Description = "IsFull property of the container when it has one empty slot.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(size - 1);
            var container = this.containerFactory.WithItemsShuffled(size, items);

            Assert.That(container.IsFull, Is.False);
        }

        [Test(Description = "IsFull property of the container when it has one full slot.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.WithItemShuffled(size, item);

            Assert.That(container.IsFull, Is.False);
        }

        [Test(Description = "IsFull property of the container when all slots are full.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var size = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Full(size, item);

            Assert.That(container.IsFull, Is.True);
        }
    }
}
