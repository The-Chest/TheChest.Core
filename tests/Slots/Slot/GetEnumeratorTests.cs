using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Slots.Slot
{
    public class GetEnumeratorTests<T> : SlotTests<T>
    {
        [Test]
        [Description("GetEnumerator returns no items for an empty slot.")]
        public void GetEnumerator_EmptySlot_ReturnsNoItems()
        {
            IEnumerable<IEnumerable<T>> slot = this.slotFactory.Empty();
            var enumeratedSlots = slot.ToArray();

            Assert.That(enumeratedSlots, Has.Length.EqualTo(1));
            CollectionAssert.IsEmpty(enumeratedSlots[0]);
        }

        [Test]
        [Description("GetEnumerator returns the item stored in the slot.")]
        public void GetEnumerator_SlotWithItem_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            IEnumerable<IEnumerable<T>> slot = this.slotFactory.Full(item);
            var enumeratedSlots = slot.ToArray();

            Assert.That(enumeratedSlots, Has.Length.EqualTo(1));
            CollectionAssert.AreEqual(new T[] { item }, enumeratedSlots[0]);
        }

        [Test]
        [Description("The non-generic GetEnumerator returns the item stored in the slot.")]
        public void GetEnumerator_NonGeneric_ReturnsItem()
        {
            var item = this.itemFactory.CreateDefault();
            IEnumerable slot = this.slotFactory.Full(item);
            var enumeratedSlots = slot.Cast<IEnumerable<T>>().ToArray();

            Assert.That(enumeratedSlots, Has.Length.EqualTo(1));
            CollectionAssert.AreEqual(new T[] { item }, enumeratedSlots[0]);
        }
    }
}
