namespace TheChest.Core.Tests.Containers.Interfaces
{
    public partial class IStackContainerTests<T>
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
            var items = this.itemFactory.CreateMany(randomSize - 1);

            var container = this.containerFactory.ShuffledItems(randomSize, randomStackSize, items);

			Assert.That(container.IsFull, Is.False);
		}

        [Test]
		public void IsFull_OneFullSlot_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();

            var container = this.containerFactory.ShuffledItems(randomSize, randomStackSize, item);

            Assert.That(container.IsFull, Is.False);
		}

        [Test]
        public void IsFull_ContainerWithItems_ReturnsFalse()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var items = this.itemFactory.CreateMany(randomSize / 2);

            var container = this.containerFactory.ShuffledItems(randomSize, randomStackSize, items);

            Assert.That(container.IsFull, Is.False);
        }

        [Test]
		public void IsFull_AllSlotsFull_ReturnsTrue()
		{
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var randomStackSize = random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
            var item = this.itemFactory.CreateDefault();

            var container = this.containerFactory.Full(randomSize, randomStackSize, item);

            Assert.That(container.IsFull, Is.True);
		}
	}
}
