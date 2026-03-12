namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test]
        public void Constructor_WithSizeAndMaxStackSize_CreatesEmptyContainer()
        {
            const int size = 5;
            const int maxStackSize = 3;

            var container = new LazyStackContainer<T>(size, maxStackSize);

            Assert.That(container.Size, Is.EqualTo(size));
            Assert.That(container.IsEmpty, Is.True);
            Assert.That(container.IsFull, Is.False);
        }
    }
}
