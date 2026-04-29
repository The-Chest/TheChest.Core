namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test]
        public void Constructor_NoParameters_CreatesContainerWithDefaultSize()
        {
            var container = new LazyStackContainer<T>();

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(20));
                Assert.That(container.IsEmpty, Is.True);
                Assert.That(container.IsFull, Is.False);
            });
        }

        [Test]
        public void Constructor_SizeAndMaxStackSize_CreatesContainerWithGivenSize()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var maxStackSize = this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = new LazyStackContainer<T>(size, maxStackSize);

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(size));
                Assert.That(container.IsEmpty, Is.True);
                Assert.That(container.IsFull, Is.False);
            });
        }

        [Test]
        public void Constructor_NegativeSize_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => new LazyStackContainer<T>(-1, 1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
