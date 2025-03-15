using System.Linq;
using TheChest.Core.Slots.Extensions;

namespace TheChest.Core.Tests.Slots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.Throws<ArgumentNullException>(() => slot!.Contains(default));
        }

        [Test]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();
            var item = this.itemFactory.CreateDefault();
            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_DifferentItem_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var randomItem = this.itemFactory.CreateRandom();
            var slot = this.slotFactory.FullSlot(randomItem);

            Assert.That(slot.Contains(item), Is.False);
        }

        [Test]
        public void Contains_ContainsItem_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var sameItem = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.FullSlot(sameItem);

            Assert.That(slot.Contains(item), Is.True);
        }
    }
}
