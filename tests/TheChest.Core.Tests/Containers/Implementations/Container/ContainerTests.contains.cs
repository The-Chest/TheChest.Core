namespace TheChest.Core.Tests.Containers.Implementations
{
    public partial class ContainerTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.EmptyContainer();
            Assert.Throws<ArgumentNullException>(() => container.Contains(default!));
        }
    }
}
