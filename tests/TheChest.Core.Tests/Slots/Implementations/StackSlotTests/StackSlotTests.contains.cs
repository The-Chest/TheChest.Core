namespace TheChest.Core.Tests.Slots.Implementations
{
    public partial class StackSlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default(T)!), Throws.ArgumentNullException);
        }
    }
}
