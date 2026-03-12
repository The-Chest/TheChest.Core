namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test]
        public void Constructor_WithoutParameters_CreatesEmptyContainerWithZeroSize()
        {
            var container = new Container<T>();

            Assert.That(container.Size, Is.EqualTo(0));
            Assert.That(container.IsEmpty, Is.True);
            Assert.That(container.IsFull, Is.True);
        }
    }
}
