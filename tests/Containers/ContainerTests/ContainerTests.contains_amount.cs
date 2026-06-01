using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test(Description = "ContainsAmount method throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains With Amount")]
        [Category("Wrong Parameters")]
        [Category("Behavior")]
        [Category("Exception")]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);
            Assert.That(
                () => container.Contains(default!, 1),
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Description("ContainsAmount method throws an ArgumentOutOfRangeException when a non-positive amount is passed.")]
        [TestCase(0)]
        [TestCase(-1)]
        [Category("Contains With Amount")]
        [Category("Wrong Parameters")]
        [Category("Behavior")]
        [Category("Exception")]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);

            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => container.Contains(item, amount),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("amount")
            );
        }

        [Test(Description = "ContainsAmount method returns false when the item is not present in the container.")]
        [Category("Contains With Amount")]
        [Category("Valid Parameters")]
        [Category("Result")]
        [Category("Failure")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var slot = this.containerFactory.Empty(size);

            Assert.That(slot.Contains(default!, 1), Is.False);
        }

        [Test(Description = "ContainsAmount method returns true when the item is present in the container with the specified amount.")]
        [Category("Contains With Amount")]
        [Category("Valid Parameters")]
        [Category("Result")]
        [Category("Success")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var slot = this.containerFactory.Full(size, default!);

            var amount = this.random.Next(1, size + 1);
            Assert.That(slot.Contains(default!, amount), Is.True);
        }
    }
}
