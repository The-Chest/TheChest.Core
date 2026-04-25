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
                Assert.That(result[0].Contains(item), Is.True);
                Assert.That(result[1].Amount, Is.EqualTo(1));
                Assert.That(result[1].Contains(item), Is.True);
            });
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
                Assert.That(result[0].Contains(item), Is.True);
            });
        }
    }
}
