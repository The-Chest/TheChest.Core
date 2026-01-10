namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class ILazyStackContainerTests<T>
    {
        [Test]
        public void ContainsAmount_EmptyContainer_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.Empty();
            Assert.That(container.Contains(item), Is.False);
        }

        [Test]
        public void ContainsAmount_NotFoundItem_ReturnsFalse()
        {
            var items = this.itemFactory.CreateManyRandom(10);
            var container = this.containerFactory.ShuffledItems(10, 5, items);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 20), Is.False);
        }

        [Test]
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
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var items = this.itemFactory.CreateManyRandom(5).ToList();
            items.AddRange(this.itemFactory.CreateMany(5));
            var container = this.containerFactory.ShuffledItems(10, 5, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 5), Is.True);
        }

        [Test]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateRandom();
            var items = this.itemFactory.CreateMany(9)
                .Append(item).ToArray();
            var container = this.containerFactory.ShuffledItems(10, 5, items.ToArray());

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(container.Contains(paramItem, 5), Is.True);
        }
    }
}
