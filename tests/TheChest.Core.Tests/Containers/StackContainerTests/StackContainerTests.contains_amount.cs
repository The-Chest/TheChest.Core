using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.Empty();
            Assert.Throws<ArgumentNullException>(() => container.Contains(default!, 1));
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(default!, 1), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.containerFactory.Full(10, 10, default!);
            Assert.That(slot.Contains(default!, 10), Is.True);
        }

        [Test]
        [IgnoreIfValueType]
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
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Empty();
            Assert.Throws<ArgumentOutOfRangeException>(() => container.Contains(item, amount));
        }
    }
}
