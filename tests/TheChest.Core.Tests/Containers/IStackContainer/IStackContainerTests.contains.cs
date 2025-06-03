using TheChest.Core.Containers.Extensions;

namespace TheChest.Core.Tests.Containers
{
    public partial class IStackContainerTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.That(() => container.Contains(default!), Throws.ArgumentNullException);
        }

        [Test]
        public void Contains_EmptyContainer_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.EmptyContainer();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
        public void Contains_AllItemsDifferentFromParam_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.FullContainer(10, 1, item);

            var paramItem = this.itemFactory.CreateRandom();
            Assert.That(container.Contains(paramItem), Is.False);
        }

        [Test]
        public void Contains_OneItemEqualsToParam_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var items = this.itemFactory.CreateManyRandom(9)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItemsContainer(10, 10, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem), Is.True);
        }
    }
}
