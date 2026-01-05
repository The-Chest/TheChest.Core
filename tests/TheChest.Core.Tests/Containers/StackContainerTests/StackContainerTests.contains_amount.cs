using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.Throws<ArgumentNullException>(() => container.Contains(default!, 1));
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.EmptyContainer();
            Assert.That(slot.Contains(default!, 1), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.containerFactory.FullContainer(10, 10, default!);
            Assert.That(slot.Contains(default!, 10), Is.True);
        }

        [Test]
        [IgnoreIfValueType]
        public void ContainsAmount_NotEnoughItems_ReturnsFalse()
        {
            var items = this.itemFactory.CreateMany(5)
                .Concat(this.itemFactory.CreateManyRandom(5))
                .ToArray();

            //TODO: improve container factory to allow specific items in slots
            var container = this.containerFactory.ShuffledItemsContainer(10, 10, items);

            var item = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(item, 6), Is.False);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.EmptyContainer();
            Assert.Throws<ArgumentOutOfRangeException>(() => container.Contains(item, amount));
        }
    }
}
