namespace TheChest.Core.Tests.Slots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void StackAmount_BiggerThanMaxAmount_ThrowsException()
        {
            var maxAmount = random.Next(10,20);
            Assert.That(
                () => this.slotFactory.WithItem(this.itemFactory.CreateDefault(), maxAmount + 1, maxAmount),
                Throws.InnerException
                    .With.TypeOf<ArgumentOutOfRangeException>()
                    .And.Message.StartsWith("The item amount cannot be bigger than max amount")
            );
        }
    }
}
