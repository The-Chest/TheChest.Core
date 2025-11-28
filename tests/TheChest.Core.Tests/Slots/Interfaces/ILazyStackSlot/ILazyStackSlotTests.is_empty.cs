namespace TheChest.Core.Tests.Slots.Interfaces
{
    public partial class ILazyStackSlotTests<T>
    {
        [Test]
        public void IsEmpty_FullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);
            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_WithContent_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, 1, 10);

            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_NoContent_ReturnsTrue()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_ZeroAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, 0, 10);

            Assert.That(slot.IsEmpty, Is.True);
        }
    }
}
