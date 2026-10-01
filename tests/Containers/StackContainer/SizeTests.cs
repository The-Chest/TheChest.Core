using NUnit.Framework;
namespace TheChest.Core.Tests.Containers.StackContainer
{
    public class SizeTests<T> : StackContainerTests<T>
    {
        [Test]
        [Description("Size should be set to the specified value when the container is created with an initial size.")]
        public void Size_WithInitialValue_SetsSizeToSpecifiedValue()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);

            Assert.That(container.Size, Is.EqualTo(size));
        }
    }
}
