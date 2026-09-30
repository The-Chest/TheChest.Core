using NUnit.Framework;
namespace TheChest.Core.Tests.Slots.Slot
{
    public class IsFullTests<T> : SlotTests<T>
    {
        [Test]
        [Description("IsFull returns true for a full slot.")]
        public void IsFull_CurrentItemNotNull_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        [Description("IsFull returns false for an empty slot.")]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var slot = this.slotFactory.Empty();

            Assert.That(slot.IsFull, Is.False);
        }
    }
}
