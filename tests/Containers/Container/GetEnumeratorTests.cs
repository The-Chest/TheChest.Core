using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Containers.Container
{
    public class GetEnumeratorTests<T> : ContainerTests<T>
    {
        [Test]
        [Description("GetEnumerator returns all empty slots for an empty container.")]
        public void GetEnumerator_EmptyContainer_ReturnsEmptySlots()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.Empty(size);
            var enumeratedSlots = container.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(size));
                Assert.That(enumeratedSlots.Select(slot => slot.Count()), Is.All.EqualTo(0));
            });
        }

        [Test]
        [Description("GetEnumerator returns every slot, including empty slots, with its items.")]
        public void GetEnumerator_ReturnsSlotsAndItems()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(size);
            var container = this.containerFactory.WithItemsShuffled(size + 1, items);
            var enumeratedSlots = container.ToArray();
            var nonEmptySlots = enumeratedSlots.Where(slot => slot.Any()).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(size + 1));
                Assert.That(nonEmptySlots, Has.Length.EqualTo(items.Length));
            });
            CollectionAssert.AreEquivalent(items, enumeratedSlots.SelectMany(slot => slot));
        }

        [Test]
        [Description("The non-generic GetEnumerator returns each slot and its items.")]
        public void GetEnumerator_NonGeneric_ReturnsSlotsAndItems()
        {
            var items = this.itemFactory.CreateMany(2);
            var container = this.containerFactory.WithItemsShuffled(3, items);
            IEnumerable enumerable = container;
            var enumeratedSlots = enumerable.Cast<IEnumerable<T>>().ToArray();
            var nonEmptySlots = enumeratedSlots.Where(slot => slot.Any()).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedSlots, Has.Length.EqualTo(3));
                Assert.That(nonEmptySlots, Has.Length.EqualTo(items.Length));
            });
            CollectionAssert.AreEquivalent(items, enumeratedSlots.SelectMany(slot => slot));
        }
    }
}
