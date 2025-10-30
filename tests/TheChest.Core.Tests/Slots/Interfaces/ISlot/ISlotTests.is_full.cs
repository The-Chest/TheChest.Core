namespace TheChest.Core.Tests.Slots.Interfaces
{
    public abstract partial class ISlotTests<T>
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemNotNull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }
    }
}
