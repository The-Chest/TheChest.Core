using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        public void Contains_EmptyContainer_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Empty();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
        public void Contains_AllItemsDifferentFromParam_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Full(10, 1, item);

            var paramItem = this.itemFactory.CreateRandom();
            Assert.That(container.Contains(paramItem), Is.False);
        }

        [Test]
        public void Contains_OneItemEqualsToParam_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(9)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(10, 10, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem), Is.True);
        }

        [Test]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.Empty();
            Assert.That(() => container.Contains(default!), Throws.ArgumentNullException);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(default(T)!), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.containerFactory.Full(20, 10, default(T)!);
            Assert.That(slot.Contains(default(T)!), Is.True);
        }
    }
}
