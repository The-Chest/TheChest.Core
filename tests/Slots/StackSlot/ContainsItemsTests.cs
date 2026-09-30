using System;
using NUnit.Framework;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.StackSlot
{
    public class ContainsItemsTests<T> : StackSlotTests<T>
    {
        [Test]
        [Description("Contains returns false when no items are passed in the parameters.")]
        public void ContainsItems_EmptyParams_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var contains = slot.Contains(Array.Empty<T>());

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when the slot is empty and no items are passed in the parameters.")]
        public void ContainsItems_EmptySlot_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            var result = slot.Contains(Array.Empty<T>());

            Assert.That(result, Is.False);
        }

        [Test]
        [Description("Contains returns false when only one of the items in the parameters is contained in the slot.")]
        public void ContainsItems_ContainingOnlyOne_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                this.itemFactory.CreateRandom(),
            };
            var contains = slot.Contains(items);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns false when none of the items in the parameters are contained in the slot.")]
        public void ContainsItems_ContainingNoItemsFromParams_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2]
            {
                this.itemFactory.CreateRandom(),
                this.itemFactory.CreateRandom(),
            };
            var contains = slot.Contains(items);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when all items in the parameters are contained in the slot.")]
        public void ContainsItems_AllItems_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                this.itemFactory.CreateDefault(),
            };
            var contains = slot.Contains(items);

            Assert.That(contains, Is.True);
        }
        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed in the parameters for reference types.")]
        [IgnoreIfValueType]
        public void ContainsItems_ParamsWithNullItem_ThrowsArgumentNullException()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                default!
            };
            Assert.That(
                () => slot.Contains(items), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("items")
            );
        }

        [Test]
        [Description("Contains returns false when a default value item is passed in the parameters for reference types and primitive types.")]
        [IgnoreIfReferenceType]
        [IgnoreIfPrimitiveType]
        public void ContainsItems_ParamsWithDefaultValue_ReturnsFalse()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                default!
            };
            var contains = slot.Contains(items);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when a default value item is passed in the parameters for value types and primitive types.")]
        [IgnoreIfValueType]
        [IgnoreIfReferenceType]
        public void ContainsItems_PrimitiveParamsWithDefaultValue_ReturnsTrue()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Full(this.itemFactory.CreateDefault(), maxStackSize);

            var items = new T[2];
            var contains = slot.Contains(items);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed in the parameters for reference types and primitive types.")]
        public void ContainsItems_NullItem_ThrowsArgumentNullException()
        {
            var maxStackSize = this.GenerateStackSize();
            var slot = this.slotFactory.Empty(maxStackSize);

            var items = default(T[]);
            Assert.That(
                () => slot.Contains(items), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("items")
            );
        }
    }
}
