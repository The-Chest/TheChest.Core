using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Containers.StackContainer
{
    public class GetEnumeratorTests<T> : StackContainerTests<T>
    {
        [Test]
        [Description("GetEnumerator returns all empty slots for an empty stack container.")]
        public void GetEnumerator_EmptyStackContainer_ReturnsEmptySlots()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);
            var enumeratedSlots = container.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(size));
                Assert.That(enumeratedSlots.Select(slot => slot.Count()), Is.All.EqualTo(0));
            });
        }

        [Test]
        [Description("GetEnumerator returns every slot, including empty slots, with its items.")]
        public void GetEnumerator_StackContainerWithSlots_ReturnsSlotsAndItems()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.ShuffledItems(size, stackSize, item);
            var enumeratedSlots = container.ToArray();
            var nonEmptySlots = enumeratedSlots.Where(slot => slot.Any()).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(size));
                Assert.That(nonEmptySlots, Has.Length.EqualTo(1));
            });
            CollectionAssert.AreEqual(Enumerable.Repeat(item, stackSize), nonEmptySlots[0]);
        }

        [Test]
        [Description("The non-generic GetEnumerator returns each slot and its items.")]
        public void GetEnumerator_NonGeneric_ReturnsSlotsAndItems()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            IEnumerable container = this.containerFactory.ShuffledItems(size, stackSize, item);
            var enumeratedSlots = container.Cast<IEnumerable<T>>().ToArray();
            var nonEmptySlots = enumeratedSlots.Where(slot => slot.Any()).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(size));
                Assert.That(nonEmptySlots, Has.Length.EqualTo(1));
            });
            CollectionAssert.AreEqual(Enumerable.Repeat(item, stackSize), nonEmptySlots[0]);
        }
    }
}
