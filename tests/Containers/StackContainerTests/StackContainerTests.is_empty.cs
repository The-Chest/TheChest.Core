namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("IsEmpty property returns true when the container has empty slots.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        [Description("IsEmpty property returns false when the container has some empty slots.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.ShuffledItems(size, stackSize, item);

            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        [Description("IsEmpty property returns false when the container has no empty slots.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(size, stackSize, item);

            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
