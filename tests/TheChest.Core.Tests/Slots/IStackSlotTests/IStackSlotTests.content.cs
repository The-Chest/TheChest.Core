namespace TheChest.Core.Tests.Slots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void Content_Get_ReturnsArrayWithAmountSize()
        {
            var maxStack = random.Next(5, 20);
            var amount = maxStack / random.Next(2, maxStack);

            var slot = this.slotFactory.WithItem(this.itemFactory.CreateDefault(), amount, maxStack);

            Assert.That(slot.Content, Has.Count.EqualTo(amount));
        }
    }
}
