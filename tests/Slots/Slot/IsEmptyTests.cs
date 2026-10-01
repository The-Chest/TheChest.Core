using NUnit.Framework;
namespace TheChest.Core.Tests.Slots.Slot
{
    public class IsEmptyTests<T> : SlotTests<T>
    {
        [Test]
        [Description("IsEmpty returns true for a slot with value type content.")]
        public void IsEmpty_CurrentItemDefault_ReturnsTrue()
        {
            var slot = this.slotFactory.Empty();

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        [Description("IsEmpty returns false for a slot with content.")]
        public void IsEmpty_WithCurrentItem_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            Assert.That(slot.IsEmpty, Is.False);
        }
    }
}
