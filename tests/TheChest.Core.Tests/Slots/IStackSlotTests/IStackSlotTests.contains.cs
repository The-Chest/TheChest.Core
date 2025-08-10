namespace TheChest.Core.Tests.Slots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default!, 1), Throws.ArgumentNullException);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ContainsAmount_InvalidAmount_ThrowsArgumentOutOfRangeException(int amount)
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(item, amount), Throws.TypeOf<ArgumentOutOfRangeException>().And.Message.Contains("amount"));
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

        [Test]
        public void ContainsAmount_MaxStackAmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, 10);
            var slot = this.slotFactory.WithItem(item, amount);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = amount + this.random.Next(1, 10);

            Assert.That(slot.Contains(paramItem, paramAmount), Is.False);
        }

        [Test]
        public void ContainsAmount_AmountSmallerThanSearchedAmount_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, 10);
            var slot = this.slotFactory.WithItem(item, amount);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = this.random.Next(11, 20);

            Assert.That(slot.Contains(paramItem, paramAmount), Is.False);
        }

        [Test]
        public void ContainsAmount_AmountEqualThanSearchedAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(1, 10);
            var slot = this.slotFactory.WithItem(item, amount);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = amount;

            Assert.That(slot.Contains(paramItem, paramAmount), Is.True);
        }

        [Test]
        public void ContainsAmount_AmountBiggerThanSearchedAmount_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var amount = this.random.Next(11, 20);
            var slot = this.slotFactory.WithItem(item, amount, 20);

            var paramItem = this.itemFactory.CreateDefault();
            var paramAmount = this.random.Next(1, 10);

            Assert.That(slot.Contains(paramItem, paramAmount), Is.True);
        }
    }
}
