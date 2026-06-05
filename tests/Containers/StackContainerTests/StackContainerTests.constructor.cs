using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("Constructor Method does create an empty container with one slot when no parameters are provided.")]
        public void Constructor_NoParameters_CreatesEmptyContainerWithOneSlot()
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
        [IgnoreIfValueType]
        [Description("Constructor Method throws ArgumentNullException when size and max stack size are provided for a reference type.")]
        public void Constructor_SizeAndMaxStackSize_ForReferenceType_ThrowsArgumentNullException()
        {
            Assert.That(
                () => new StackContainer<T>(2, 1),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        [IgnoreIfReferenceType]
        [Description("Constructor Method does create grouped stacks when size and max stack size are provided for a value type.")]
        public void Constructor_SizeAndMaxStackSize_ForValueType_CreatesGroupedStacks()
        {
            const int size = 4;
            const int maxStackSize = 3;

            var container = new StackContainer<T>(size, maxStackSize);

            Assert.Multiple(() =>
            {
                Assert.That(container.Size, Is.EqualTo(2));
                Assert.That(container.IsEmpty, Is.False);
                Assert.That(container.IsFull, Is.False);
            });
        }

        [Test]
        [Description("Constructor Method throws ArgumentOutOfRangeException when max stack size is less than or equal to zero.")]
        public void Constructor_MaxStackSizeLessOrEqualZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => new StackContainer<T>(2, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
