using NUnit.Framework;
namespace TheChest.Core.Tests.Containers.LazyStackContainer
{
    public class SizeTests<T> : LazyStackContainerTests<T>
    {
        [Test]
		[Description("Size property returns the correct size of the container.")]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.Empty();

            Assert.That(container.Size, Is.EqualTo(20));
        }
    }
}
