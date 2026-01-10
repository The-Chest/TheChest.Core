namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class ILazyStackContainerTests<T>
    {
        [Test]
		public void IsFull_EmptySlots_ReturnsFalse()
		{
			var container = this.containerFactory.Empty();

			Assert.That(container.IsFull, Is.False);
		}

		[Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
	}
}
