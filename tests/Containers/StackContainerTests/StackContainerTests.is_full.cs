namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("IsFull property returns false when the container has empty slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_EmptySlots_ReturnsFalse()
		{
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

			Assert.That(container.IsFull, Is.False);
		}

		[Test]
        [Description("IsFull property returns false when the container has some empty slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_OneEmptySlot_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var items = this.itemFactory.CreateMany(size - 1);

            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

			Assert.That(container.IsFull, Is.False);
		}

        [Test]
        [Description("IsFull property returns false when the container has some empty slots and some full slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();

            var container = this.containerFactory.ShuffledItems(size, stackSize, item);

            Assert.That(container.IsFull, Is.False);
		}

        [Test]
        [Description("IsFull property returns false when the container has some empty slots and some full slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_ContainerWithItems_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var items = this.itemFactory.CreateMany(size / 2);

            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
        [Description("IsFull property returns true when the container has no empty slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();

            var container = this.containerFactory.Full(size, stackSize, item);

            Assert.That(container.IsFull, Is.True);
		}
	}
}
