using NUnit.Framework;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.StackSlot
{
    public class ContainsTests<T> : StackSlotTests<T>
    {
        [Test]
        [Description("Contains returns false when the slot is empty, regardless of the item passed.")]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when a different item is passed than the one contained in the slot.")]
        public void Contains_DifferentItem_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var randomItem = this.itemFactory.CreateRandom();
            var slot = this.slotFactory.Full(randomItem, maxStackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the same item is passed as the one contained in the slot.")]
        public void Contains_ContainsItem_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var sameItem = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(sameItem, maxStackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed.")]
        [IgnoreIfValueType]
        public void ContainsItem_NullItem_ThrowsArgumentNullException()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            Assert.That(
                () => slot.Contains(default(T)!), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
        [Description("Contains returns false when the default value of the item type is passed to an empty slot, and true when passed to a full slot.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            var item = default(T)!;
            var contains = slot.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the default value of the item type is passed to a full slot that contains the default value.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(default!, maxStackSize);

            var item = default(T)!;
            var contains = slot.Contains(item);

            Assert.That(contains, Is.True);
        }
    }
}
