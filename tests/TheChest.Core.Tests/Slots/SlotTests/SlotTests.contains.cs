namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            Assume.That(!typeof(T).IsValueType, "Test applies only to reference types.");
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default!), Throws.ArgumentNullException);
        }

        [Test]
        public void Contains_DefaultValue_ReturnsFalse()
        {
            Assume.That(typeof(T).IsValueType, "Test applies only to value types.");
            var slot = this.slotFactory.EmptySlot();
            var result = slot.Contains(default!);
            Assert.That(result, Is.False);
        }
    }
}
