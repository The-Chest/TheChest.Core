namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test]
        public void Constructor_NoParameters_CreatesEmptyContainer()
        {
            var container = new Container<T>();

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.Zero);
                Assert.That(container.IsEmpty, Is.True);
                Assert.That(container.IsFull, Is.True);
            });
        }

        [Test]
        public void Constructor_Size_CreatesContainerWithGivenSize()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = new Container<T>(size);

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
                () => new Container<T>(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Constructor_ItemsAndSize_WhenItemsIsNull_ThrowsArgumentNullException()
        {
            Assert.That(
                () => new Container<T>(null!, 1),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ItemsAndSize_WhenSizeEqualsItemsLength_CreatesFullContainer()
        {
            var amount = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(amount);

            var container = new Container<T>(items, items.Length);

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(items.Length));
                Assert.That(container.IsEmpty, Is.False);
                Assert.That(container.IsFull, Is.True);
            });
        }

        [Test]
        public void Constructor_ItemsAndSize_WhenSizeIsGreaterThanItemsLength_CreatesPartiallyFilledContainer()
        {
            var amount = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(amount);
            var size = amount + this.random.Next(1, MIN_SIZE_TEST);

            var container = new Container<T>(items, size);

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(size));
                Assert.That(container.IsEmpty, Is.False);
                Assert.That(container.IsFull, Is.False);
            });
        }

        [Test]
        public void Constructor_ItemsAndSize_WhenSizeIsSmallerThanItemsLength_ThrowsArgumentException()
        {
            var amount = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(amount);

            Assert.That(
                () => new Container<T>(items, amount - 1),
                Throws.TypeOf<ArgumentException>());
        }
    }
}
