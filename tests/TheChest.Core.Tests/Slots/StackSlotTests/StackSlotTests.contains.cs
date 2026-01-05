using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void ContainsItem_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default(T)!), Throws.ArgumentNullException);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.Contains(default(T)!), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var slot = this.slotFactory.FullSlot(default!);
            Assert.That(slot.Contains(default(T)!), Is.True);
        }
    }
}
