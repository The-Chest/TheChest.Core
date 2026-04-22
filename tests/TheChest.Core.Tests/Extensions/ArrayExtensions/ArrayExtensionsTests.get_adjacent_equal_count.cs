using TheChest.Core.Extensions;

namespace TheChest.Core.Tests.Extensions
{
    public partial class ArrayExtensionsTests<T>
    {
        [Test]
        public void GetAdjacentEqualCount_NoAdjacentEqualItems_ReturnsStartIndex()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateDifferentFrom(first);
            var array = new[] { first, second };

            var result = array.GetAdjacentEqualCount(startIndex: 0, maxCount: 5);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetAdjacentEqualCount_AdjacentEqualItemsExist_ReturnsLastAdjacentIndex()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateDifferentFrom(first);
            var array = new[] { first, first, first, second };

            var result = array.GetAdjacentEqualCount(startIndex: 0, maxCount: 10);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetAdjacentEqualCount_AdjacentEqualItemsExceedMaxCount_ReturnsIndexLimitedByMaxCount()
        {
            var item = this.itemFactory.CreateRandom();
            var array = new[] { item, item, item, item };

            var result = array.GetAdjacentEqualCount(startIndex: 0, maxCount: 2);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetAdjacentEqualCount_StartIndexHasPreviousEqualItems_OnlyCountsForwardFromStartIndex()
        {
            var first = this.itemFactory.CreateRandom();
            var second = this.itemFactory.CreateDifferentFrom(first);
            var array = new[] { second, first, first, first };

            var result = array.GetAdjacentEqualCount(startIndex: 1, maxCount: 10);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetAdjacentEqualCount_MaxCountIsOne_ReturnsStartIndex()
        {
            var item = this.itemFactory.CreateRandom();
            var array = new[] { item, item, item };

            var result = array.GetAdjacentEqualCount(startIndex: 0, maxCount: 1);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
