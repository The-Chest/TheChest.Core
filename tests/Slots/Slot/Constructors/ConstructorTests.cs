using NUnit.Framework;
using TheChest.Core.Slots;
using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.Slot.Constructors
{
    public class ConstructorTests<T> : SlotTests<T>
    {
        [Test]
        [Description("The constructor creates an empty slot when no parameters are provided.")]
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
