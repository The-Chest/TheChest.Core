namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test(Description = "Constructor with no parameters creates a container with the default size.")]
        [Category("Constructor")]
        [Category("Default")]
        [Category("Behavior")]
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

        [Test(Description = "Constructor with size and max stack size parameters creates a container with the given size.")]
        [Category("Constructor")]
        [Category("Behavior")]
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

        [Description("Constructor with invalid size parameter throws an ArgumentOutOfRangeException.")]
        [TestCase(-1)]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_InvalidSizeSize_ThrowsArgumentOutOfRangeException(int multiplier)
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST) * multiplier;
            var maxStackSize = this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            Assert.That(
                () => new LazyStackContainer<T>(size, maxStackSize),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("size")
            );
        }

        [Description("Constructor with invalid max stack size parameter throws an ArgumentOutOfRangeException.")]
        [TestCase(-1)]
        [TestCase(0)]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_InvalidMaxStackSize_ThrowsArgumentOutOfRangeException(int multiplier)
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var maxStackSize = this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST) * multiplier;

            Assert.That(
                () => new LazyStackContainer<T>(size, maxStackSize),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("maxStackSize")
            );
        }
    }
}
