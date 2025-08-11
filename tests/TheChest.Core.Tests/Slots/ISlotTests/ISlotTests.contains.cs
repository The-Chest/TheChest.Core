namespace TheChest.Core.Tests.Slots
{
    public abstract partial class ISlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.Throws<ArgumentNullException>(() => slot.Contains(default));
        }

        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_SlotWithItem_DifferentFromParam_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var paramItem = this.itemFactory.CreateRandom();
            Assert.That(slot.Contains(paramItem), Is.False);
        }

        [Test]
        public void Contains_SlotWithItem_EqualsItemFromParam_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(item);

            var paramItem = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(paramItem), Is.True);
        }
    }
}
