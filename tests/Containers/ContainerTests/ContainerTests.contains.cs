using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
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
            var container = this.containerFactory.Empty();
            Assert.That(
                ()=> container.Contains(item: default!), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
        [Description("Contains method returns false when the item is not present in the container.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(item: default!), Is.False);
        }

        [Test]
        [Description("Contains method returns true when the item is present in the container.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = default(T);
            var slot = this.containerFactory.Full(size, item!);

            Assert.That(slot.Contains(item: default!), Is.True);
        }


        [Test]
        [Description("Contains method returns false when the container is empty.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void Contains_EmptyContainer_ReturnsFalse()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);

            var item = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
        [Description("Contains method returns false when all items in the container are different from the parameter.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void Contains_AllItemsDifferentFromParam_ReturnsFalse()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(size, item);

            var paramItem = this.itemFactory.CreateRandom();
            Assert.That(container.Contains(paramItem), Is.False);
        }

        [Test]
        [Description("Contains method returns true when at least one item in the container is equal to the parameter.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void Contains_OneItemEqualsToParam_ReturnsTrue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.WithItemsShuffled(size, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem), Is.True);
        }
    }
}
