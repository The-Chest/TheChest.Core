using NUnit.Framework;
namespace TheChest.Core.Tests.Containers.Container
{
    public class SizeTests<T> : ContainerTests<T>
    {
        [Test]
        [Description("Size property of the container when it has initial value.")]
        public void Size_WithInitialValue_SetsSizeToSpecifiedValue()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);

            Assert.That(container.Size, Is.EqualTo(size));
        }
    }
}
