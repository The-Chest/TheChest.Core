namespace TheChest.Core.Tests.Containers
{
    public abstract partial class IStackContainerTests<T>
    {
        [Test]
		public void IsFull_EmptySlots_ReturnsFalse()
		{
			var container = this.containerFactory.EmptyContainer();

			Assert.That(container.IsFull, Is.False);
		}

		[Test]
		public void IsFull_OneEmptySlot_ReturnsFalse()
		{
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemsContainer(
                randomSize, randomStackSize,
                this.itemFactory.CreateMany(randomSize - 1)
            ); 

			Assert.That(container.IsFull, Is.False);
		}

        [Test]
        public void IsFull_OneSlotAlmostFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemsContainer(
                randomSize, randomStackSize,
                this.itemFactory.CreateMany(randomSize - 1)
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
		public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemsContainer(
                randomSize, randomStackSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.False);
		}

        [Test]
        [Obsolete("This test is the same as 'IsFull_OneFullSlot_ReturnsFalse', fix it")]
        public void IsFull_AllSlotsAlmostFull_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var container = this.containerFactory.ShuffledItemsContainer(
                randomSize, randomStackSize,
                this.itemFactory.CreateDefault()
            );

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
		public void IsFull_AllSlotsFull_ReturnsTrue()
		{
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);

            var container = this.containerFactory.FullContainer(randomSize, randomStackSize, this.itemFactory.CreateDefault());

            Assert.That(container.IsFull, Is.True);
		}
	}
}
