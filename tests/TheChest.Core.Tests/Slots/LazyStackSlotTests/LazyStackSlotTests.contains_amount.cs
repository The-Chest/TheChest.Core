using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.EmptySlot();
            Assert.That(
                () => slot.Contains(item, amount), 
                Throws.TypeOf<ArgumentOutOfRangeException>().And.Message.Contains("amount")
             );
        }

        [Test]
        [IgnoreIfValueType]
        public void ContainsAmount_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(
                () => slot.Contains(default!, 1),
                Throws.TypeOf<ArgumentNullException>().And.Message.Contains("item")
             );
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_NullItem_ReturnFalseIfEmpty()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(slot.Contains(default!, 1), Is.False);
        }

        [Test]
        [IgnoreIfReferenceType]
        public void ContainsAmount_NullItem_ReturnTrueIfFull()
        {
            var slot = this.slotFactory.FullSlot(default!);
            Assert.That(slot.Contains(default!, 1), Is.True);
        }
    }
}
