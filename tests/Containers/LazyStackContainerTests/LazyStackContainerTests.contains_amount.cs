using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test]
		[Description("Contains method throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains")]
        [Category("Reference Type")]
        [Category("Behavior")]
        [Category("Exception")]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var amount = this.random.Next(1, stackSize);
            Assert.That(
                () => container.Contains(default!, amount),
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
		[Description("Contains method returns false when a default value item is passed to an empty container.")]
        [Category("Contains")]
        [Category("Value Type")]
        [Category("Result")]
        [Category("Failure")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var amount = this.random.Next(1, stackSize);
            Assert.That(container.Contains(default!, amount), Is.False);
        }

        [Test]
		[Description("Contains method returns true when a default value item is passed to a full container.")]
        [Category("Contains")]
        [Category("Value Type")]
        [Category("Result")]
        [Category("Success")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrueIfFull()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var slot = this.containerFactory.Full(size, stackSize, default!);

            Assert.That(slot.Contains(default!, stackSize), Is.True);
        }

        [Description("Contains method throws an ArgumentOutOfRangeException when an invalid amount is passed.")]
        [Category("Contains")]
        [Category("Behavior")]
        [Category("Exception")]
        [TestCase(0)]
        [TestCase(-1)]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => container.Contains(item, amount),
                Throws.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo("amount")
            );
        }

        [Test]
		[Description("Contains method returns false when the container is empty, regardless of the item passed.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_EmptyContainer_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, stackSize);
            Assert.That(container.Contains(item, amount), Is.False);
        }

        [Test]
		[Description("Contains method returns false when the item is not found in the container.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_NotFoundItem_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var items = this.itemFactory.CreateManyRandom(size);
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, stackSize);
            Assert.That(container.Contains(paramItem, amount), Is.False);
        }

        [Test]
		[Description("Contains method returns false when the total amount of the item in the container is smaller than the searched amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_AmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, stackSize) + stackSize;
            Assert.That(container.Contains(paramItem, amount), Is.False);
        }

        [Test]
		[Description("Contains method returns true when the total amount of the item in the container is equal to the searched amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var halfAmount = size / 2;
            var items = this.itemFactory.CreateManyRandom(halfAmount).ToList();
            items.AddRange(this.itemFactory.CreateMany(halfAmount));
            var container = this.containerFactory.ShuffledItems(size, stackSize, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, halfAmount), Is.True);
        }

        [Test]
		[Description("Contains method returns true when the total amount of the item in the container is bigger than the searched amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateRandom();
            var items = this.itemFactory.CreateMany(size - 1).Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 5), Is.True);
        }

        [Test]
		[Description("Contains method returns true when the total amount of the item in the container is bigger than the searched amount and the items are in multiple slots.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_ValidSearchedAmount_ItemsInMultipleSlots_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var halfAmount = size / 2;
            var items = this.itemFactory.CreateManyRandom(halfAmount).ToList();
            items.AddRange(this.itemFactory.CreateMany(halfAmount));

            var container = this.containerFactory.ShuffledItems(size, stackSize, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, halfAmount);
            Assert.That(container.Contains(paramItem, amount), Is.True);
        }
    }
}
