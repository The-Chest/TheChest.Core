namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test]
        [Description("The constructor throws an ArgumentOutOfRangeException when the size parameter is negative.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_NegativeSize_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => new Container<T>(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("size")
            );
        }

        [Test]
        [Description("The constructor throws an ArgumentException when the size parameter is smaller than the length of the items array.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_ItemsAndSize_SizeSmallerThanItemsLength_ThrowsArgumentException()
        {
            var amount = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(amount);

            Assert.That(
                () => new Container<T>(items, amount - 1),
                Throws.TypeOf<ArgumentException>().With.Property("ParamName").EqualTo("size")
            );
        }

        [Test]
        [Description("The constructor throws an ArgumentNullException when the items parameter is null.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_ItemsAndSize_NullItems_ThrowsArgumentNullException()
        {
            Assert.That(
                () => new Container<T>(null!, 1),
                Throws.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo("items")
            );
        }

        [Test]
        [Description("The constructor creates an empty container when no parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
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
        [Description("The constructor creates an empty container with the given size.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
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
        [Description("The constructor creates a full container when the size parameter is equal to the length of the items array.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_ItemsAndSize_SizeEqualsItemsLength_CreatesFullContainer()
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
        [Description("The constructor creates a partially filled container when the size parameter is greater than the length of the items array.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_ItemsAndSize_SizeGreaterThanItemsLength_CreatesPartiallyFilledContainer()
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
    }
}
