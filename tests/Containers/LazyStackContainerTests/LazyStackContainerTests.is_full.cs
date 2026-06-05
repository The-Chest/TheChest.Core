namespace TheChest.Core.Tests.Containers.LazyStackContainerTests
{
    public partial class LazyStackContainerTests<T>
    {
        [Test(Description = "IsFull property returns true when all slots in the container are full.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_AllSlotsFull_ReturnsTrue()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.Full(
                randomSize,
                randomStackSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.True);
        }

        [Test(Description = "IsFull property returns false when the container has empty slots.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_EmptySlots_ReturnsFalse()
		{
			var container = this.containerFactory.Empty();

			Assert.That(container.IsFull, Is.False);
		}

		[Test(Description = "IsFull property returns false when the container has one empty slot.")]
		[Category("IsFull")]
		[Category("Property")]
		public void IsFull_OneEmptySlot_ReturnsFalse()
		{
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItems(
                randomSize, 
                randomStackSize,
                this.itemFactory.CreateMany(randomSize - 1)
            ); 

			Assert.That(container.IsFull, Is.False);
		}

        [Test(Description = "IsFull property returns false when the container has one slot that is not full.")]
        [Category("IsFull")]
        [Category("Property")]
        public void IsFull_OneSlotFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItems(
                randomSize, 
                randomStackSize,
                this.itemFactory.CreateMany(1)
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test(Description = "IsFull property returns false when the container has one full slot.")]
        [Category("IsFull")]
        [Category("Property")]
		public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItems(
                randomSize, 
                randomStackSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.False);
		}
	}
}
