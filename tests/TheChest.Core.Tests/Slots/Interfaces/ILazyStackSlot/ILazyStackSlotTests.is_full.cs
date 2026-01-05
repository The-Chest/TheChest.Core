using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests
{
    public partial class ILazyStackSlotTests<T>
    {
        [Test]
        public void IsFull_NoContent_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_FullSlot_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        [IgnoreIfValueType]
        public void IsFull_FullAmountWithNoContent_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(default!, 10, 10);
            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void IsFull_FullAmountWithDefaultContent_ReturnsTrue()
        {
            var slot = this.slotFactory.WithItem(default!, 10, 10);
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        public void IsFull_ItemNotMaxAmount_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, 5, 10);
            Assert.That(slot.IsFull, Is.False);
        }
    }
}
