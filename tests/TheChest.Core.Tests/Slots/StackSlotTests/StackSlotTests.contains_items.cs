using TheChest.Core.Tests.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    public partial class StackSlotTests<T>
    {
        [Test]
        [IgnoreIfValueType]
        public void ContainsItems_ParamsWithNullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                default!
            };
            Assert.That(() => slot.Contains(items), Throws.ArgumentNullException);
        }

        [Test]
        [IgnoreIfReferenceType]
        [IgnoreIfPrimitiveType]
        public void ContainsItems_ParamsWithDefaultValue_ReturnsFalse()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                default!
            };
            Assert.That(slot.Contains(items), Is.False);
        }

        [Test]
        [IgnoreIfValueType]
        [IgnoreIfReferenceType]
        public void ContainsItems_PrimitiveParamsWithDefaultValue_ReturnsTrue()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2];
            Assert.That(slot.Contains(items), Is.True);
        }

        [Test]
        public void ContainsItems_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.EmptySlot();
            Assert.That(() => slot.Contains(default(T[])!), Throws.ArgumentNullException);
        }
    }
}
