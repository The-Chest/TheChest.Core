namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class IStackContainerTests<T>
    {
        [Test]
        public void Size_NoInitialValue_SetsSizeToTwenty()
        {
            var container = this.containerFactory.Empty();

            Assert.That(container.Size, Is.EqualTo(20));
        }
    }
}
