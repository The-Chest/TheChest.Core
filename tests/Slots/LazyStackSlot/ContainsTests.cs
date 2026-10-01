using NUnit.Framework;
using NUnit.Framework.Internal;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.LazyStackSlot
{
    public class ContainsTests<T> : LazyStackSlotTests<T>
    {
        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed for reference types.")]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            Assert.That(
                () => slot.Contains(default!), 
                Throws.ArgumentNullException.And.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
        [Description("Contains returns false when the default value is passed and the slot is empty.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsFalseIfEmpty()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            var contains = slot.Contains(default!);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when the slot is empty, regardless of the item passed.")]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(0, stackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when a different item is passed than the one contained in the slot.")]
        public void Contains_DifferentItem_ReturnsFalse()
        {
            var stackSize = this.GenerateStackSize();
            var randomItem = this.itemFactory.CreateRandom();
            var slot = this.slotFactory.Full(randomItem, stackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item); 
            
            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the same item is passed that is contained in the slot.")]
        public void Contains_ContainsItem_ReturnsTrue()
        {
            var stackSize = this.GenerateStackSize();
            var sameItem = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(sameItem, stackSize);

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains returns true when the default value is passed and the slot is full.")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_ReturnsTrueIfFull()
        {
            var stackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(default!, stackSize);

            var contains = slot.Contains(default!);

            Assert.That(contains, Is.True);
        }
    }
}
