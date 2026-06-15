using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
		[Description("Contains method throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains")]
        [Category("Behavior")]
        [Category("Exception")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(
                () => container.Contains(default!), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
		[Description("Contains method returns false when the item is the default value and the container is empty.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);
            
            var contains = container.Contains(default!);

            Assert.That(contains, Is.False);
        }

        [Test]
		[Description("Contains method returns true when the item is the default value and the container is full of that default value.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Full(size, stackSize, default!);

            var contains = container.Contains(default!);

            Assert.That(contains, Is.True);
        }

        [Test]
		[Description("Contains method returns false when the container is empty, regardless of the item.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void Contains_EmptyContainer_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = container.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
		[Description("Contains method returns false when all items in the container are different from the parameter item.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void Contains_AllItemsDifferentFromParam_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(size, stackSize, item);

            var paramItem = this.itemFactory.CreateRandom();
            var contains = container.Contains(paramItem);

            Assert.That(contains, Is.False);
        }

        [Test]
		[Description("Contains method returns true when at least one item in the container is equal to the parameter item.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void Contains_OneItemEqualsToParam_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var paramItem = this.itemFactory.CreateDefault();
            var contains = container.Contains(paramItem);

            Assert.That(contains, Is.True);
        }
    }
}
