using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        [Description("The Contains method returns false when the slot is empty, regardless of the item provided.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Failure")]
        public void Contains_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.Empty();

            var item = this.itemFactory.CreateDefault();
            var contains = slot.Contains(item);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("The Contains method returns false when the slot contains an item that is different from the one provided as a parameter.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void Contains_SlotWithItem_DifferentFromParam_ReturnsFalse()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            var paramItem = this.itemFactory.CreateRandom();
            var contains = slot.Contains(paramItem);

            Assert.That(contains, Is.False);
        }

        [Test]
        [Description("Contains returns true when the same item is passed as the one contained in the slot.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        public void Contains_SlotWithItem_EqualsItemFromParam_ReturnsTrue()
        {
            var item = this.itemFactory.CreateDefault();
            var slot = this.slotFactory.Full(item);

            var paramItem = this.itemFactory.CreateDefault();
            var contains = slot.Contains(paramItem);

            Assert.That(contains, Is.True);
        }

        [Test]
        [Description("Contains throws an ArgumentNullException when a null item is passed.")]
        [Category("Contains")]
        [Category("Behavior")]
        [Category("Exception")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void Contains_NullItem_ThrowsArgumentNullException()
        {
            var slot = this.slotFactory.Empty();
            Assert.That(
                () => slot.Contains(default!),
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("item")
            );
        }

        [Test]
        [Description("Contains returns true when the default value of the item type is passed to a slot that contains the default value.")]
        [Category("Contains")]
        [Category("Result")]
        [Category("Success")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Contains_DefaultValue_DefaultItem_ReturnsTrue()
        {
            var slot = this.slotFactory.Full(default!);

            var contains = slot.Contains(default!);

            Assert.That(contains, Is.True);
        }
    }
}
