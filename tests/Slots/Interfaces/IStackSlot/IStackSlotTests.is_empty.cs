namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlotTests
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void IsEmpty_StackAmountZero_ReturnsTrue()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), 0,10);
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNull_ReturnsTrue()
        {
            var slot = this.slotFactory.Empty();
            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_CurrentItemNotNull_ReturnsFalse()
        {
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(),1 , 10);
            Assert.That(slot.IsEmpty, Is.False);
        }
    }
}
