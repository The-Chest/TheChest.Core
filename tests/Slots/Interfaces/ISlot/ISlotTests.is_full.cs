namespace TheChest.Core.Tests.Slots.Interfaces.ISlotTests
{
    public partial class ISlotTests<T>
    {
        [Test]
        public void IsFull_CurrentItemNotNull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);
            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.Empty();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }
    }
}
