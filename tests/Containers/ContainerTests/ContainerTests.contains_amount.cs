using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test(Description = "ContainsAmount method throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains With Amount")]
        [Category("Behavior")]
        [Category("Exception")]
        [Category("Reference Type")]
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

        [Test(Description = "ContainsAmount method returns false when the item is not present in the container.")]
        [Category("Contains With Amount")]
        [Category("Result")]
        [Category("Failure")]
        [Category("ValueType")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var slot = this.containerFactory.Empty(size);

            Assert.That(slot.Contains(default!, 1), Is.False);
        }


        [Test(Description = "ContainsAmount method returns true when the item is present in the container with the specified amount.")]
        [Category("Contains With Amount")]
        [Category("Result")]
        [Category("Success")]
        [Category("ValueType")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var slot = this.containerFactory.Full(size, default!);

            var amount = this.random.Next(1, size + 1);
            Assert.That(slot.Contains(default!, amount), Is.True);
        }

        [Description("ContainsAmount method throws an ArgumentOutOfRangeException when a non-positive amount is passed.")]
        [TestCase(0)]
        [TestCase(-1)]
        [Category("Contains With Amount")]
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

        [Test(Description = "ContainsAmount method returns false when the container is empty, regardless of the item.")]
        [Category("Contains With Amount")]
        [Category("Behavior")]
        [Category("Failure")]
        public void ContainsAmount_EmptyContainer_ReturnsFalse()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);

            var item = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test(Description = "ContainsAmount method returns false when the item is not found in the container, regardless of the amount.")]
        [Category("Contains With Amount")]
        [Category("Behavior")]
        [Category("Failure")]
        public void ContainsAmount_NotFoundItem_ReturnsFalse()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateManyRandom(size);
            var container = this.containerFactory.WithItemsShuffled(size, items);

            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, size + 1);
            Assert.That(container.Contains(item, amount), Is.False);
        }

        [Test(Description = "ContainsAmount method returns false when the total amount of the item in the container is smaller than the searched amount.")]
        [Category("Contains With Amount")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_AmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.WithItemsShuffled(size, items);

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(2, size + 1);
            Assert.That(container.Contains(paramItem, amount), Is.False);
        }

        [Test(Description = "ContainsAmount method returns true when the total amount of the item in the container is equal to the searched amount.")]
        [Category("Contains With Amount")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var halfSize = size / 2;
            var items = this.itemFactory.CreateManyRandom(halfSize).ToList();
            items.AddRange(this.itemFactory.CreateMany(halfSize));
            var container = this.containerFactory.WithItemsShuffled(size, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, halfSize), Is.True);
        }

        [Test(Description = "ContainsAmount method returns true when the total amount of the item in the container is bigger than the searched amount.")]
        [Category("Contains With Amount")]
        [Category("Valid Parameters")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var item = this.itemFactory.CreateRandom();
            var items = this.itemFactory.CreateMany(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.WithItemsShuffled(size, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, size - 1);
            Assert.That(container.Contains(paramItem, amount), Is.True);
        }
    }
}
