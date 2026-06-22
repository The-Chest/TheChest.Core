namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        [Description("IsEmpty returns true for a slot with value type content.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_CurrentItemDefault_ReturnsTrue()
        {
            var slot = this.slotFactory.Empty();

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        [Description("IsEmpty returns false for a slot with content.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_WithCurrentItem_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            Assert.That(slot.IsEmpty, Is.False);
        }

        [Test]
        [Description("IsEmpty returns false for a full slot.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_IsFull_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            Assert.That(slot.IsEmpty, Is.False);
            Assert.That(slot.IsEmpty, Is.Not.EqualTo(slot.IsFull));
        }
    }
}
