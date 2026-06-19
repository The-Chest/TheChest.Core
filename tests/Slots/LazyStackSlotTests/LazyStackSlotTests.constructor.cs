namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [Test]
        [Description("The constructor initializes the Amount and MaxAmount properties with default values when no parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
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
        [Description("The constructor initializes the Amount and MaxAmount properties correctly when valid parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_ItemAndAmountAndMaxAmount_InitializesCorrectly()
        {
            var maxAmount = this.GenerateStackSize();
            var amount = this.random.Next(1, maxAmount);
            var item = this.itemFactory.CreateDefault();

            var slot = new LazyStackSlot<T>(item, amount, maxAmount);

            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.EqualTo(amount));
                Assert.That(slot.MaxAmount, Is.EqualTo(maxAmount));
            });
        }

        [Test]
        [Description("The constructor throws an ArgumentNullException when the item parameter is null.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_AmountGreaterThanMaxAmount_ThrowsArgumentOutOfRangeException()
        {
            var stackSize = this.GenerateStackSize();
            var amount = stackSize + 1;
            var item = this.itemFactory.CreateDefault();

            Assert.That(
                () => new LazyStackSlot<T>(item, amount, stackSize),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Property("ParamName").EqualTo("amount")
                    .And.Message.Contains("The item amount cannot be bigger than max amount")
            );
        }

        [Test]
        [Description("The constructor throws an ArgumentOutOfRangeException when the amount parameter is smaller than zero.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_AmountSmallerThanZero_ThrowsArgumentOutOfRangeException()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => new LazyStackSlot<T>(item, amount * -1, stackSize),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Property("ParamName").EqualTo("amount")
                    .And.Message.Contains("The amount property cannot be smaller than zero")
            );
        }

        [Test]
        [Description("The constructor throws an ArgumentOutOfRangeException when the max amount parameter is smaller than zero.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_MaxAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            var stackSize = this.GenerateStackSize();
            var amount = this.random.Next(1, stackSize);
            var item = this.itemFactory.CreateDefault();
            Assert.That(
                () => new LazyStackSlot<T>(item, amount, stackSize * -1),
                Throws.Exception
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Property("ParamName").EqualTo("maxAmount")
                    .And.Message.Contains("The max amount property cannot be smaller than zero")
            );
        }
    }
}
