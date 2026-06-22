using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
        [Description("The constructor creates an empty slot when no parameters are provided.")]
        [Category("Constructor")]
        [Category("Behavior")]
        [Category("Success")]
        public void Constructor_NoParameters_CreatesEmpty()
        {
            var slot = new Slot<T>();

            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.True);
                Assert.That(slot.IsFull, Is.False);
            });
        }

        [Test]
        [Description("The constructor creates an empty slot when a null item is provided for reference types.")]
        [Category("Constructor")]
        [Category("Reference Type")]
        [IgnoreIfValueType]
        public void Constructor_NullItem_CreatesEmpty()
        {
            var slot = new Slot<T>(default!);

            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.True);
                Assert.That(slot.IsFull, Is.False);
            });
        }

        [Test]
        [Description("The constructor creates a full slot when a default value is provided for value types.")]
        [Category("Constructor")]
        [Category("Value Type")]
        [IgnoreIfReferenceType]
        public void Constructor_DefaultValue_CreatesFull()
        {
            var slot = new Slot<T>(default!);

            Assert.Multiple(() =>
            {
                Assert.That(slot.IsEmpty, Is.False);
                Assert.That(slot.IsFull, Is.True);
            });
        }
    }
}
