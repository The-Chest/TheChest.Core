namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [Test]
        public void Constructor_NoParameters_InitializesWithDefaultValues()
        {
            var slot = new LazyStackSlot<T>();
            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.Zero);
                Assert.That(slot.MaxAmount, Is.EqualTo(1));
            });
        }

        [Test]
        public void Constructor_ItemAndAmountAndMaxAmount_InitializesCorrectly()
        {
            var item = this.itemFactory.CreateDefault();
            int amount = this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            int maxAmount = this.random.Next(amount, MAX_STACK_SIZE_TEST + MIN_STACK_SIZE_TEST);

            var slot = new LazyStackSlot<T>(item, amount, maxAmount);
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
                () => new LazyStackSlot<T>(item, 6, 5),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The item amount cannot be bigger than max amount")
            );
        }

        [Test]
        public void Constructor_AmountSmallerThanZero_ThrowsArgumentOutOfRangeException()
        {
            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => new LazyStackSlot<T>(item, -1, 5),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The amount property cannot be smaller than zero")
            );
        }

        [Test]
        public void Constructor_MaxAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => new LazyStackSlot<T>(item, 5, -1),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The max amount property cannot be smaller than zero")
            );
        }
    }
}
