namespace TheChest.Core.Tests.Slots.Implementations.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.Throws<ArgumentNullException>(() => slot.Contains(default!));
        }
    }
}
