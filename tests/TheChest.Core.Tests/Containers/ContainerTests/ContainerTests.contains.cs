using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Containers.ContainerTests
{
    public partial class ContainerTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var container = this.containerFactory.Empty();
            Assert.Throws<ArgumentNullException>(() => container.Contains(default!));
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.containerFactory.Empty();
            Assert.That(slot.Contains(item: default!), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var item = default(T);
            var slot = this.containerFactory.Full(20, item!);
            Assert.That(slot.Contains(item: default!), Is.True);
        }
    }
}
