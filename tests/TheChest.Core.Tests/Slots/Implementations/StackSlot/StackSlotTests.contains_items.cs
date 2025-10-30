namespace TheChest.Core.Tests.Slots.Implementations
{
    public partial class StackSlotTests<T>
    {
        [Test]
        public void ContainsItems_ParamsWithNull_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                default!
            };
            Assert.That(() => slot.Contains(items), Throws.ArgumentNullException);
        }
    }
}
