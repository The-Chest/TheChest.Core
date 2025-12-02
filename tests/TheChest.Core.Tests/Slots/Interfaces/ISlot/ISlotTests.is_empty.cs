namespace TheChest.Core.Tests.Slots.Interfaces.ISlotTests
{
    public partial class ISlotTests<T>
    {
        [Test]
        public void IsEmpty_CurrentItemDefault_ReturnsTrue()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_WithCurrentItem_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);
            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        public void IsEmpty_IsFull_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            Assert.That(slot.IsEmpty, Is.False);
            Assert.That(slot.IsEmpty, Is.Not.EqualTo(slot.IsFull));
        }
    }
}
