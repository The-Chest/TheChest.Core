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
            var amount = this.random.Next(1, 10);
            var maxAmount = this.random.Next(11, 20);
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxAmount);

            Assert.That(slot.AvailableAmount, Is.EqualTo(maxAmount - amount));
        }
    }
}
