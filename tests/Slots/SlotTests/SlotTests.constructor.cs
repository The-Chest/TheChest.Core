using TheChest.Core.Tests.Common.Configurations.Attributes;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    public partial class SlotTests<T>
    {
        [Test]
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
