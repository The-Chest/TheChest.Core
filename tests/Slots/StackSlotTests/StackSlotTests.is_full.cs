using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        [Description("IsFull returns false when the content is null, even if the amount is equal to the max stack size.")]
        [Category("IsFull")]
        [Category("Property")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void IsFull_CurrentItemNull_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = maxStackSize;
            var slot = this.slotFactory.WithItem(default!, amount, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [Description("IsFull returns true when the content is default, even if the amount is equal to the max stack size.")]
        [Category("IsFull")]
        [Category("Property")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void IsFull_CurrentItemDefault_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = maxStackSize;
            var slot = this.slotFactory.WithItem(default!, amount, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [Description("IsFull returns false when the amount is less than the max stack size and the content is not null.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_CurrentItemNotAtMaxStack_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize - 1);

            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxStackSize);

            Assert.That(slot.IsFull, Is.False);
        }

        [Test]
        [Description("A slot cannot be full if it is empty.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_SlotIsEmpty_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();

            var slot = this.slotFactory.Empty(maxStackSize);

            Assert.That(slot.IsFull, Is.False);
            Assert.That(slot.IsFull, Is.Not.EqualTo(slot.IsEmpty));
        }

        [Test]
        [Description("IsFull returns true when the amount is equal to the max stack size and the content is not null.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_CurrentItemInMaxStack_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = maxStackSize;

            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxStackSize);

            Assert.That(slot.IsFull, Is.True);
        }
    }
}
