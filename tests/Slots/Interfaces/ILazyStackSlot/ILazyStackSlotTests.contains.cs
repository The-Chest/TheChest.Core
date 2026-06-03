namespace TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests
{
    public partial class ILazyStackSlotTests<T>
    {
        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.Empty();
            var item = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_DifferentItem_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var randomItem = this.itemFactory.CreateRandom();
            var slot = this.slotFactory.Full(randomItem);

            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_ContainsItem_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var sameItem = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(sameItem);

            Assert.That(slot.Contains(item), Is.True);
        }
    }
}
