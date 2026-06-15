namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("Size should be set to the specified value when the container is created with an initial size.")]
        [Category("Size")]
        [Category("Property")]
        public void Size_WithInitialValue_SetsSizeToSpecifiedValue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(container.Size, Is.EqualTo(size));
        }
    }
}
