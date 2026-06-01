using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test(Description = "Contains method throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains")]
        [Category("Wrong Parameters")]
        [Category("Behavior")]
        [Category("Exception")]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.Empty();
            Assert.That(
                ()=> container.Contains(item: default!), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test(Description = "Contains method returns false when the item is not present in the container.")]
        [Category("Contains")]
        [Category("Valid Parameters")]
        [Category("Result")]
        [Category("Failure")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(item: default!), Is.False);
        }

        [Test(Description = "Contains method returns true when the item is present in the container.")]
        [Category("Contains")]
        [Category("Valid Parameters")]
        [Category("Result")]
        [Category("Success")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var item = default(T);
            var slot = this.containerFactory.Full(20, item!);
            Assert.That(slot.Contains(item: default!), Is.True);
        }
    }
}
