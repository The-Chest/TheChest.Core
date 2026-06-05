namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.Empty();

            Assert.That(container.Size, Is.EqualTo(20));
        }
    }
}
