using NUnit.Framework;
namespace TheChest.Core.Tests.Slots.LazyStackSlot
{
    public class AvailableAmountTests<T> : LazyStackSlotTests<T>
    {
        [Test]
        [Description("AvailableAmount property returns the correct value for an empty slot.")]
        public void AvailableAmount_EmptySlot_ReturnsMaxAmount()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);
            
            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount));
        }

        [Test]
        [Description("AvailableAmount property returns zero for a full slot.")]
        public void AvailableAmount_FullSlot_ReturnsZero()
        {
            var stackSize = this.GenerateStackSize();
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item, stackSize);
            
            Assert.That(slot.AvailableAmount, Is.Zero);
        }

        [Test]
        [Description("AvailableAmount property returns the correct value for a slot with an item.")]
        public void AvailableAmount_SlotWithItem_ReturnsMaxAmountLessAmount()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.WithItem(item, amount, stackSize);
            
            Assert.That(slot.AvailableAmount, Is.EqualTo(slot.MaxAmount - slot.Amount));
        }
    }
}
