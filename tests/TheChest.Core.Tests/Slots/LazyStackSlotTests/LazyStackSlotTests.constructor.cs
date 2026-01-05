namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T> 
    {
        [Test]
        public void Constructor_NoParameters_InitializesWithDefaultValues()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.Zero);
                Assert.That(slot.MaxAmount, Is.EqualTo(1));
            });
        }

        [Test]
        public void Constructor_ItemArrayBiggerThanMaxAmount_ThrowsArgumentException()
        {
            var item = this.itemFactory.CreateDefault();
            int amount = 5;
            int maxAmount = 5;
            var slot = this.slotFactory.WithItem(item, amount, maxAmount);
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
                () => this.slotFactory.WithItem(item, 6, 5),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The item amount cannot be bigger than max amount (Parameter 'amount')")
            );
        }

        [Test]
        public void Constructor_MaxAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => this.slotFactory.WithItem(item, 5, -1),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.Contains("The max amount property cannot be smaller than zero (Parameter 'maxAmount')")
            );
        }

        [Test]
        public void Constructor_ValidParameters_InitializesCorrectly()
        {
            var item = this.itemFactory.CreateDefault();
            int amount = 5;
            int maxAmount = 10;

            var slot = this.slotFactory.WithItem(item, amount, maxAmount);

            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.EqualTo(amount));
                Assert.That(slot.MaxAmount, Is.EqualTo(maxAmount));
            });
        }
    }
}
