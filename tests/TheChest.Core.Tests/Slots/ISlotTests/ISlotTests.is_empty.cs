namespace TheChest.Tests.Slots
{
    public abstract partial class ISlotTests<T>
    {
        [Test]
        public void IsEmpty_CurentItemNull_ReturnsTrue()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurentItemNotNull_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);
            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_SlotIsFull_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            Assert.That(slot.IsEmpty, Is.False);
            Assert.That(slot.IsEmpty, Is.Not.EqualTo(slot.IsFull));
        }
    }
}
