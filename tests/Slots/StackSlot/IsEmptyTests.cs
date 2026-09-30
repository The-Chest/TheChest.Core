using NUnit.Framework;
namespace TheChest.Core.Tests.Slots.StackSlot
{
    public class IsEmptyTests<T> : StackSlotTests<T>
    {
        [Test]
        [Description("Tests that IsEmpty returns true when the stack amount is zero.")]
        public void IsEmpty_StackAmountZero_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), 0, maxStackSize);

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        [Description("Tests that IsEmpty returns false when the stack amount is greater than zero.")]
        public void IsEmpty_CurrentItemNull_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            Assert.That(slot.IsEmpty, Is.True);
        }

        [Test]
        [Description("Tests that IsEmpty returns false when the stack amount is greater than zero and the current item is not null.")]
        public void IsEmpty_CurrentItemNotNull_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize);
            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxStackSize);

            Assert.That(slot.IsEmpty, Is.False);
        }
    }
}
