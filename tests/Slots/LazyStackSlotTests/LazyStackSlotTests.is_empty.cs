namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [Test]
        [Description("IsEmpty returns false for a full slot.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_FullSlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(item, maxStackSize);

            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        [Description("IsEmpty returns false for a slot with content.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_WithContent_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize);
            var slot = this.slotFactory.WithItem(item, amount, maxStackSize);

            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        [Description("IsEmpty returns true for an empty slot.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_NoContent_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, maxStackSize);

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        [Description("IsEmpty returns true for a slot with zero amount.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_ZeroAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.WithItem(item, 0, maxStackSize);

            Assert.That(slot.IsEmpty, Is.True);
        }
    }
}
