namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class StackContainerTests<T>
    {
        [Test]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.That(() => container.Contains(default!, 1), Throws.ArgumentNullException);
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
