namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        [Description("AvailableAmount property returns the correct value for an empty slot.")]
        [Category("AvailableAmount")]
        [Category("Property")]
        public void AvailableAmount_EmptySlot_ReturnsMaxAmount()
        {
            var maxAmount = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxAmount);

            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount));
        }

        [Test]
        [Description("AvailableAmount property returns zero for a full slot.")]
        [Category("AvailableAmount")]
        [Category("Property")]
        public void AvailableAmount_FullSlot_ReturnsZero()
        {
            var maxAmount = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxAmount);
            
            Assert.That(slot.AvailableAmount, Is.Zero);
        }

        [Test]
        [Description("AvailableAmount property returns the correct value for a slot with an item.")]
        [Category("AvailableAmount")]
        [Category("Property")]
        public void AvailableAmount_SlotWithItem_ReturnsMaxAmountLessAmount()
        {
            var maxAmount = this.GenerateStackSize();
            var amount = this.random.Next(1, maxAmount);
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxAmount);

            Assert.That(slot.AvailableAmount, Is.EqualTo(maxAmount - amount));
        }
    }
}
