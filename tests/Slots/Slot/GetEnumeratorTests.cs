using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TheChest.Core.Tests.Slots.Slot
{
    public class GetEnumeratorTests<T> : SlotTests<T>
    {
        [Test]
        [Description("GetEnumerator returns no items for an empty slot.")]
        public void GetEnumerator_EmptySlot_ReturnsNoItems()
        {
            IEnumerable<T> slot = this.slotFactory.Empty();

            CollectionAssert.IsEmpty(slot);
        }

        [Test]
        [Description("GetEnumerator returns the item stored in the slot.")]
        public void GetEnumerator_SlotWithItem_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            IEnumerable<T> slot = this.slotFactory.Full(item);

            CollectionAssert.AreEqual(new T[] { item }, slot);
        }

        [Test]
        [Description("The non-generic GetEnumerator returns the item stored in the slot.")]
        public void GetEnumerator_NonGeneric_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            IEnumerable slot = this.slotFactory.Full(item);

            CollectionAssert.AreEqual(new T[] { item }, slot);
        }
    }
}
