using NUnit.Framework;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.LazyStackSlot
{
    public class IsFullTests<T> : LazyStackSlotTests<T>
    {
        [Test]
        [Description("IsFull returns false for an empty slot.")]
        public void IsFull_NoContent_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [Description("IsFull returns true for a full slot.")]
        public void IsFull_FullSlot_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item, maxStackSize);

            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        [Description("IsFull returns false when the amount is equal to the max stack size but the content is the default value for value types.")]
        [IgnoreIfValueType]
        public void IsFull_FullAmountWithNoContent_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.WithItem(default!, maxStackSize, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [Description("IsFull returns true when the amount is equal to the max stack size and the content is the default value for reference types.")]
        [IgnoreIfReferenceType]
        public void IsFull_FullAmountWithDefaultContent_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.WithItem(default!, maxStackSize, maxStackSize);

            Assert.That(slot.IsFull, Is.True);
        }

        [Test]
        [Description("IsFull returns false when the amount is less than the max stack size.")]
        public void IsFull_ItemNotMaxAmount_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize - 1);
            var slot = this.slotFactory.WithItem(item, amount, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }
    }
}
