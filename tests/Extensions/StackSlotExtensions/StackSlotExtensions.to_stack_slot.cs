using System;
using NUnit.Framework;
using TheChest.Core.Tests.Common.Extensions.Slots;
using TheChest.Core.Slots.Extensions;

namespace TheChest.Core.Tests.Extensions
{
    public partial class StackSlotExtensions<T>
    {
        [Test]
        public void ToStackSlots_EmptyItems_ReturnsEmptySlotsArray()
        {
            var items = System.Array.Empty<T>();

            var result = items.ToStackSlots(maxStackSize: 3);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ToStackSlots_AdjacentEqualItemsExceedMaxStackSize_SplitsIntoMultipleSlots()
        {
            var item = this.itemFactory.CreateRandom();
            var items = new[] { item, item, item };

            var result = items.ToStackSlots(maxStackSize: 2);

            Assert.That(result, Has.Length.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Amount, Is.EqualTo(2));
                Assert.That(result[0].GetContents(), Is.EqualTo(new[] { item, item }));
                Assert.That(result[1].Amount, Is.EqualTo(1));
                Assert.That(result[1].GetContents(), Is.EqualTo(new[] { item }));
            });
        }

        [Test]
        public void ToStackSlots_NoAdjacentEqualItems_CreatesOneSlotPerItem()
        {
            var firstItem = this.itemFactory.CreateRandom();
            var secondItem = this.itemFactory.CreateDifferentFrom(firstItem);
            var thirdItem = this.itemFactory.CreateDifferentFrom(secondItem);
            var items = new[] { firstItem, secondItem, thirdItem };

            var result = items.ToStackSlots(maxStackSize: 3);

            Assert.That(result, Has.Length.EqualTo(items.Length));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Amount, Is.EqualTo(1));
                Assert.That(result[0].GetContents(), Is.EqualTo(new[] { firstItem }));
                Assert.That(result[1].Amount, Is.EqualTo(1));
                Assert.That(result[1].GetContents(), Is.EqualTo(new[] { secondItem }));
                Assert.That(result[2].Amount, Is.EqualTo(1));
                Assert.That(result[2].GetContents(), Is.EqualTo(new[] { thirdItem }));
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ToStackSlots_MaxStackSizeIsZeroOrLess_ThrowsArgumentOutOfRangeException(int maxStackSize)
        {
            var item = this.itemFactory.CreateRandom();
            var items = new[] { item };

            Assert.Throws<ArgumentOutOfRangeException>(() => items.ToStackSlots(maxStackSize));
        }

        [Test]
        public void ToStackSlots_AdjacentEqualItemsWithinMaxStackSize_CreatesSingleSlot()
        {
            var item = this.itemFactory.CreateRandom();
            var items = new[] { item, item };

            var result = items.ToStackSlots(maxStackSize: 3);

            Assert.That(result, Has.Length.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Amount, Is.EqualTo(2));
                Assert.That(result[0].GetContents(), Is.EqualTo(new[] { item, item }));
            });
        }
    }
}
