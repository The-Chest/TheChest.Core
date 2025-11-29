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
        public void IsFull_FullAmountAndNoContent_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(default!, 10, 10);

            Assert.That(slot.IsFull, Is.False);
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
