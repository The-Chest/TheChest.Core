using TheChest.Core.Tests.Common.Configurations.Attributes;
using TheChest.Core.Tests.Common.Extensions.Containers;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
		[Description("The constructor should create an empty container with no slots when no parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_NoParameters_CreatesEmptyContainerWithNoSlots()
        {
            var container = new StackContainer<T>();

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(0));
                Assert.That(container.IsEmpty, Is.True);
                Assert.That(container.IsFull, Is.True);
            });
        }

        [Test]
		[Description("The constructor should create an empty container with the given size and max stack size, and initialize the slots accordingly.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_SizeAndMaxStackSize_CreatesEmptyContainerWithSlots()
        {
            var (size, maxStackSize) = this.GenerateRandomSizeAndStackSize();
            var container = new StackContainer<T>(size, maxStackSize);

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(size));
                Assert.That(container.GetSlots(), Has.All.With.Property("IsEmpty").True);
                Assert.That(container.IsEmpty, Is.True);
                Assert.That(container.IsFull, Is.False);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Description("The constructor should throw an ArgumentOutOfRangeException when the max stack size is less than or equal to zero.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_MaxStackSizeLessOrEqualZero_ThrowsArgumentOutOfRangeException(int maxStackSize)
        {
            var (size, _) = this.GenerateRandomSizeAndStackSize();
            Assert.That(
                () => new StackContainer<T>(size, maxStackSize),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("maxStackSize")
            );
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Description("The constructor should throw an ArgumentOutOfRangeException when the size is less than or equal to zero.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_SizeLessOrEqualZero_ThrowsArgumentOutOfRangeException(int size)
        {
            var (_, maxStackSize) = this.GenerateRandomSizeAndStackSize();
            Assert.That(
                () => new StackContainer<T>(size, maxStackSize),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("size")
            );
        }
    }
}
