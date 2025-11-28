namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void IsFull_CurentItemNull_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(default!, 1, 10);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_CurentItemInHalfMaxStack_ReturnsFalse()
        {
            var maxStack = random.Next(5,20);

            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), maxStack / 2, maxStack);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }

        [Test]
        public void IsFull_CurentItemInMaxStack_ReturnsTrue()
        {
            var maxStack = random.Next(5, 20);

            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), maxStack, maxStack);

            Assert.That(slot.IsFull, Is.True);
        }
    }
}
