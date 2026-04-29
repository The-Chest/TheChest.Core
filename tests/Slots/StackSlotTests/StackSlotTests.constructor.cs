namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        public void Constructor_NoParameters_InitializesWithDefaultValues()
        {
            var slot = new StackSlot<T>();

            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.Zero);
                Assert.That(slot.MaxAmount, Is.Zero);
            });
        }

        [Test]
        public void Constructor_ItemsAndMaxAmount_SetsAmountAndMaxAmount()
        {
            var item = this.itemFactory.CreateDefault();
            int amount = this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            int maxAmount = this.random.Next(amount, MAX_STACK_SIZE_TEST + MIN_STACK_SIZE_TEST);

            var slot = new StackSlot<T>(Enumerable.Repeat(item, amount).ToArray(), maxAmount);

            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.EqualTo(amount));
                Assert.That(slot.MaxAmount, Is.EqualTo(maxAmount));
            });
        }

        [Test]
        public void Constructor_AmountGreaterThanMaxAmount_ThrowsArgumentOutOfRangeException()
        {
            var item = this.itemFactory.CreateDefault();

            Assert.That(
                () => new StackSlot<T>(Enumerable.Repeat(item, 6).ToArray(), 5),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The content size cannot be bigger than max amount")
            );
        }

        [Test]
        public void Constructor_MaxAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => new StackSlot<T>(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The max amount cannot be smaller than zero")
            );
        }
    }
}
