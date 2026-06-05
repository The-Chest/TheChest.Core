namespace TheChest.Core.Tests.Containers.StackContainerTests
{
    public partial class StackContainerTests<T>
    {
        [Test]
        [Description("IsEmpty Property returns true when slots are empty.")]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var container = this.containerFactory.Empty();
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test]
        [Description("IsEmpty Property returns false when some slots are empty.")]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.ShuffledItems(randomSize, randomStackSize, this.itemFactory.CreateDefault());
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test]
        [Description("IsEmpty Property returns false when all slots are full.")]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.Full(randomSize, randomStackSize, this.itemFactory.CreateDefault());

            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
