using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        public void Constructor_NoParameters_CreatesEmptySlot()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.True);
                Assert.That(slot.IsFull, Is.False);
            });
        }

        [Test]
        [IgnoreIfValueType]
        public void Constructor_NullItem_CreatesEmptySlot()
        {
            var slot = this.slotFactory.FullSlot(default!);
            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.True);
                Assert.That(slot.IsFull, Is.False);
            });
        }

        [Test]
        [IgnoreIfReferenceType]
        public void Constructor_DefaultValue_CreatesFullSlot()
        {
            var slot = this.slotFactory.FullSlot(default!);
            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.False);
                Assert.That(slot.IsFull, Is.True);
            });
        }
    }
}
