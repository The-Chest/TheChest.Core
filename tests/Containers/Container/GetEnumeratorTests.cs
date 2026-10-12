using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TheChest.Core.Tests.Containers.Container
{
    public class GetEnumeratorTests<T> : ContainerTests<T>
    {
        [Test]
        [Description("GetEnumerator returns no items for an empty container.")]
        public void GetEnumerator_EmptyContainer_ReturnsNoItems()
        {
            var container = this.containerFactory.Empty();

            CollectionAssert.IsEmpty(container);
        }

        [Test]
        [Description("GetEnumerator skips empty slots and returns all stored items.")]
        public void GetEnumerator_SkipsEmptySlotsAndReturnsItems()
        {
            var size = this.random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var items = this.itemFactory.CreateMany(size);
            var container = this.containerFactory.WithItemsShuffled(size + 1, items);
            IEnumerable<T> enumerable = container;

            CollectionAssert.AreEquivalent(items, enumerable);
        }

        [Test]
        [Description("The non-generic GetEnumerator returns all stored items.")]
        public void GetEnumerator_NonGeneric_ReturnsItems()
        {
            var items = this.itemFactory.CreateMany(2);
            var container = this.containerFactory.WithItemsShuffled(3, items);
            IEnumerable enumerable = container;

            CollectionAssert.AreEquivalent(items, enumerable);
        }
    }
}
