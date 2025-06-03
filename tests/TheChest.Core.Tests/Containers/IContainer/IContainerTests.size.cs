namespace TheChest.Core.Tests.Containers
{
    public partial class IContainerTests<T>
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(20));
        }

        [Test]
        public void Size_ReturnsSlotsLength()
        {
            var container = this.containerFactory.EmptyContainer();

            Assert.That(container.Size, Is.EqualTo(container.Slots.Count));
        }
    }
}
