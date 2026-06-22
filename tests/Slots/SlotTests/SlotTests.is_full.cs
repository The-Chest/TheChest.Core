namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        [Description("IsFull returns true for a full slot.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_CurrentItemNotNull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        [Description("IsFull returns false for an empty slot.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.Empty();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }
    }
}
