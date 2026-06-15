using TheChest.Core.Tests.Common.Configurations.Attributes;
using TheChest.Core.Tests.Common.NUnit.TestCases;

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
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(
                () => container.Contains(default!, 1), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [WrongAmount]
        [Description("Contains method throws an ArgumentOutOfRangeException when a non-positive amount is passed.")]
        [Category("Contains")]
        [Category("Behavior")]
        [Category("Exception")]
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
        [Description("Contains method returns false when the item is the default value and the container is empty.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var contains = container.Contains(default!, 1);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains method returns true when the item is the default value and the container is full of that default value.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrueIfFull()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Full(size, stackSize, default!);

            var contains = container.Contains(default!, stackSize * size);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains method returns false when the container does not have enough items to meet the searched amount, even if it contains the item.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void ContainsAmount_NotEnoughItems_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var searchItemAmount = this.random.Next(1, size - 1);
            var items = this.itemFactory.CreateMany(searchItemAmount)
                .Concat(this.itemFactory.CreateManyRandom(size - searchItemAmount))
                .ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var item = this.itemFactory.CreateDefault();
            var contains = container.Contains(item, (searchItemAmount * stackSize) + 1);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains method returns false when the container is empty, regardless of the item or amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_EmptyContainer_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = container.Contains(item);
            
            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains method returns false when all items in the container are different from the parameter item, regardless of the amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void ContainsAmount_NotFoundItem_ReturnsFalse()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var items = this.itemFactory.CreateManyRandom(size);
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, stackSize * size);
            var contains = container.Contains(paramItem, amount);

            Assert.That(contains, Is.False);
        }

        [Test]
		[Description("Contains method returns false when the container has some items equal to the parameter item but not enough to meet the searched amount.")]
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
            var amount = this.random.Next(size, stackSize * size);
            var contains = container.Contains(paramItem, amount); 
            
            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains method returns true when the container has exactly the amount of items equal to the parameter item as the searched amount.")]
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
            var amount = this.random.Next(1, halfAmount);
            var contains = container.Contains(paramItem, amount); 
            
            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains method returns true when the container has more items equal to the parameter item than the searched amount.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateRandom();
            var items = this.itemFactory.CreateMany(size - 1)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, size - 1);
            var contains = container.Contains(paramItem, amount); 
            
            Assert.That(contains, Is.True);
        }
    }
}
