using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheChest.Core.Tests.Containers.LazyStackContainer
{
    public class GetEnumeratorTests<T> : LazyStackContainerTests<T>
    {
        [Test]
        [Description("GetEnumerator returns all empty slots for an empty lazy stack container.")]
        public void GetEnumerator_EmptyLazyStackContainer_ReturnsEmptySlots()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var container = this.containerFactory.Empty(size, stackSize);
            var enumeratedItems = container.ToArray();

            Assert.That(enumeratedItems, Is.Empty);
        }

        [Test]
        [Description("GetEnumerator returns every slot, including empty slots, with its items.")]
        public void GetEnumerator_LazyStackContainerWithItems_ReturnsSlotsAndItems()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            var container = this.containerFactory.ShuffledItems(size, stackSize, item);
            var enumeratedItems = container.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedItems, Has.Length.EqualTo(stackSize));
                Assert.That(enumeratedItems.Select(items => items.Count()), Is.All.EqualTo(1));
            });
            CollectionAssert.AreEqual(Enumerable.Repeat(item, stackSize), enumeratedItems.SelectMany(items => items));
        }

        [Test]
        [Description("The non-generic GetEnumerator returns each slot and its items.")]
        public void GetEnumerator_NonGeneric_ReturnsSlotsAndItems()
        {
            var (size, stackSize) = this.GenerateRandomSizeAndStackSize();
            var item = this.itemFactory.CreateDefault();
            IEnumerable container = this.containerFactory.ShuffledItems(size, stackSize, item);
            var enumeratedItems = container.Cast<IEnumerable<T>>().ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(enumeratedItems, Has.Length.EqualTo(stackSize));
                Assert.That(enumeratedItems.Select(items => items.Count()), Is.All.EqualTo(1));
            });
            CollectionAssert.AreEqual(Enumerable.Repeat(item, stackSize), enumeratedItems.SelectMany(items => items));
        }
    }
}
