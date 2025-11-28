namespace TheChest.Core.Tests.Slots.Interfaces
{
    public partial class ILazyStackSlotTests<T>
    {
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
