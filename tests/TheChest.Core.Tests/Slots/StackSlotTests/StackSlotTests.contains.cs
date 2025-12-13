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
        public void ContainsItem_DefaultValue_DefaultItem_ReturnsTrue()
        {
            var slot = this.slotFactory.FullSlot(default!);
            var result = slot.Contains(default(T)!);
            Assert.That(result, Is.True);
        }
    }
}
