using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default!), Throws.ArgumentNullException);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.Contains(default!), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.slotFactory.FullSlot(default!);
            Assert.That(slot.Contains(default!), Is.True);
        }
    }
}
