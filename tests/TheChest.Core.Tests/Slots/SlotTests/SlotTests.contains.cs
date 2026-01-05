using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
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
        public void Contains_DefaultValue_DefaultItem_ReturnsTrue()
        {
            var slot = this.slotFactory.FullSlot(default!);
            var result = slot.Contains(default!);
            Assert.That(result, Is.True);
        }
    }
}
