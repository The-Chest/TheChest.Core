using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("ContainsAmount Method returns false when the container is empty and an amount is provided.")]
        public void ContainsAmount_EmptyContainer_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Empty();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
        [Description("ContainsAmount Method returns false when the searched item with amount is not found.")]
        public void ContainsAmount_NotFoundItem_ReturnsFalse()
        {
            var items = this.itemFactory.CreateManyRandom(10);
            var container = this.containerFactory.ShuffledItems(10, 5, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 20), Is.False);
        }

        [Test]
        [Description("ContainsAmount Method returns false when the available amount is smaller than the searched amount.")]
        public void ContainsAmount_AmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(9)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(10, 5, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 20), Is.False);
        }

        [Test]
        [Description("ContainsAmount Method returns true when the available amount is equal to the searched amount.")]
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var items = this.itemFactory.CreateManyRandom(5).ToList();
            items.AddRange(this.itemFactory.CreateMany(5));
            var container = this.containerFactory.ShuffledItems(10, 5, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 5), Is.True);
        }

        [Test]
        [Description("ContainsAmount Method returns true when the available amount is bigger than the searched amount.")]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateRandom();
            var items = this.itemFactory.CreateMany(9)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(10, 5, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 5), Is.True);
        }

        [Test]
        [IgnoreIfValueType]
        [Description("ContainsAmount Method throws ArgumentNullException when the searched item with amount is null.")]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.Empty();
            Assert.Throws<ArgumentNullException>(() => container.Contains(default!, 1));
        }

        [Test]
        [IgnoreIfReferenceType]
        [Description("ContainsAmount Method returns false when the searched item with amount is a default value and the container is empty.")]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(default!, 1), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        [Description("ContainsAmount Method returns true when the searched item with amount is a default value and the container is full.")]
        public void ContainsAmount_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.containerFactory.Full(10, 10, default!);
            Assert.That(slot.Contains(default!, 10), Is.True);
        }

        [Test]
        [IgnoreIfValueType]
        [Description("ContainsAmount Method returns false when the available stacked item amount is not enough.")]
        public void ContainsAmount_NotEnoughItems_ReturnsFalse()
        {
            var size = this.random.Next(5, 20);
            var searchItemAmount = this.random.Next(1, size - 1);
            var stackSize = this.random.Next(5, 10);
            var items = this.itemFactory.CreateMany(searchItemAmount)
                .Concat(this.itemFactory.CreateManyRandom(size - searchItemAmount))
                .ToArray();
            var container = this.containerFactory.ShuffledItems(size, stackSize, items);

            var item = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(item, (searchItemAmount * stackSize) + 1), Is.False);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Description("ContainsAmount Method throws ArgumentOutOfRangeException when the searched amount is invalid.")]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Empty();
            Assert.Throws<ArgumentOutOfRangeException>(() => container.Contains(item, amount));
        }
    }
}
