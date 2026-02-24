namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlotTests
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void AvailableAmount_EmptySlot_ReturnsMaxAmount()
        {
            var slot = this.slotFactory.EmptySlot();
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
            var maxAmount = this.random.Next(10, 20);
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, 0, maxAmount);
            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount - slot.Amount));
        }
    }
}
