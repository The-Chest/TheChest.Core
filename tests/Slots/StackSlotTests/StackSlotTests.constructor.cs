namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        [Description("The constructor initializes the Amount and MaxAmount properties with default values when no parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
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
        [Description("The constructor initializes the Amount and MaxAmount properties correctly when valid items and max amount are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_ItemsAndMaxAmount_SetsAmountAndMaxAmount()
        {
            var item = this.itemFactory.CreateDefault();
            var maxAmount = this.GenerateStackSize();
            var amount = this.random.Next(1, maxAmount);

            var slot = new StackSlot<T>(Enumerable.Repeat(item, amount).ToArray(), maxAmount);

            Assert.Multiple(() =>
            {
                Assert.That(slot.Amount, Is.EqualTo(amount));
                Assert.That(slot.MaxAmount, Is.EqualTo(maxAmount));
            });
        }

        [Test]
        [Description("The constructor throws an ArgumentOutOfRangeException when the amount of items exceeds the max amount.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_AmountGreaterThanMaxAmount_ThrowsArgumentOutOfRangeException()
        {
            var maxAmount = this.GenerateStackSize();
            var item = this.itemFactory.CreateDefault();

            Assert.That(
                () => new StackSlot<T>(Enumerable.Repeat(item, maxAmount + 1).ToArray(), maxAmount),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName").EqualTo("items")
                    .And.Message.Contains("The item amount cannot be bigger than max amount")
            );
        }

        [Test]
        [Description("The constructor throws an ArgumentOutOfRangeException when the max amount is less than zero.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Exception")]
        public void Constructor_MaxAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(
                () => new StackSlot<T>(-1),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName").EqualTo("maxAmount")
                    .And.Message.Contains("The max amount cannot be smaller than zero")
            );
        }
    }
}
