namespace TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests
{
    public partial class ILazyStackSlotTests<T>
    {
        [Test]
        public void AvailableAmount_EmptySlot_ReturnsMaxAmount()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), 0);
            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount));
        }

        [Test]
        public void AvailableAmount_FullSlot_ReturnsZero()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            Assert.That(slot.AvailableAmount, Is.Zero);
        }

        [Test]
        public void AvailableAmount_SlotWithItem_ReturnsMaxAmountLessAmount()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), 0);
            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount - slot.Amount));
        }
    }
}
