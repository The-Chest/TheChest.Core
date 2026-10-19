using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Slots.LazyStackSlot
{
    public class GetEnumeratorTests<T> : LazyStackSlotTests<T>
    {
        [Test]
        [Description("GetEnumerator returns no items for an empty lazy stack slot.")]
        public void GetEnumerator_EmptySlot_ReturnsNoItems()
        {
            var maxStackSize = this.GenerateStackSize();
            IEnumerable<IEnumerable<T>> slot = this.slotFactory.Empty(0, maxStackSize);

            CollectionAssert.IsEmpty(slot);
        }

        [Test]
        [Description("GetEnumerator returns each stored item in its own sequence.")]
        public void GetEnumerator_SlotWithItems_ReturnsSingleItemSequences()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize);
            var item = this.itemFactory.CreateDefault();
            IEnumerable<IEnumerable<T>> slot = this.slotFactory.WithItem(item, amount, maxStackSize);

            CollectionAssert.AreEqual(Enumerable.Repeat(item, amount), slot.Select(items => items.Single()));
        }

        [Test]
        [Description("The non-generic GetEnumerator returns each stored item.")]
        public void GetEnumerator_NonGeneric_ReturnsItems()
        {
            var maxStackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, maxStackSize);
            var item = this.itemFactory.CreateDefault();
            IEnumerable slot = this.slotFactory.WithItem(item, amount, maxStackSize);

            CollectionAssert.AreEqual(
                Enumerable.Repeat(item, amount),
                slot.Cast<IEnumerable<T>>().SelectMany(items => items)
            );
        }
    }
}