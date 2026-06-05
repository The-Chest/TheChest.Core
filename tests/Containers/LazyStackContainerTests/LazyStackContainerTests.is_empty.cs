namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test(Description = "IsEmpty property returns true when all slots in the container are empty.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_EmptySlots_ReturnsTrue()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.Empty(randomSize, randomStackSize);
            Assert.That(container.IsEmpty, Is.True);
        }

        [Test(Description = "IsEmpty property returns false when some slots in the container are empty and some are full.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_SomeEmptySlots_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.ShuffledItems(
                randomSize, 
                randomStackSize, 
                this.itemFactory.CreateDefault()
            );
            Assert.That(container.IsEmpty, Is.False);
        }

        [Test(Description = "IsEmpty property returns false when all slots in the container are full.")]
        [Category("IsEmpty")]
        [Category("Property")]
        public void IsEmpty_AllSlotsFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.Full(
                randomSize, 
                randomStackSize, 
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsEmpty, Is.False);
        }
    }
}
