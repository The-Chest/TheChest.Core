namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    public partial class LazyStackSlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default!), Throws.ArgumentNullException);
        }
    }
}
