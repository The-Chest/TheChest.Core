using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Slots.StackSlot
{
    public class GetEnumeratorTests<T> : StackSlotTests<T>
    {
        [Test]
        [Description("GetEnumerator returns no items for an empty stack slot.")]
        public void GetEnumerator_EmptyStackSlot_ReturnsNoItems()
        {
            var stackSize = this.GenerateStackSize();

            IEnumerable<T> slot = this.slotFactory.Empty(stackSize);

            CollectionAssert.IsEmpty(slot);
        }

        [Test]
        [Description("GetEnumerator returns all items stored in the stack slot in order.")]
        public void GetEnumerator_StackSlotWithItems_ReturnsItems()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();

            IEnumerable<T> slot = this.slotFactory.WithItem(item, amount, stackSize);

            CollectionAssert.AreEqual(Enumerable.Repeat(item, amount), slot);
        }

        [Test]
        [Description("The non-generic GetEnumerator returns all items stored in the stack slot.")]
        public void GetEnumerator_NonGeneric_ReturnsItems()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();

            IEnumerable slot = this.slotFactory.WithItem(item, amount, stackSize);

            CollectionAssert.AreEqual(Enumerable.Repeat(item, amount), slot);
        }
    }
}
