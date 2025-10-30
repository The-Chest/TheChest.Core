namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class LazyStackContainerTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.That(() => container.Contains(default!), Throws.ArgumentNullException);
        }
    }
}
