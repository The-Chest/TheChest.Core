namespace TheChest.Core.Tests.Containers
{
    public abstract partial class IContainerTests<T>
    {
        [Test]
        public void Index_ValidIndex_ReturnsSlotItemFromIndex()
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.FullContainer(randomSize, this.itemFactory.CreateDefault());

            var randomIndex = random.Next(0, randomSize - 1);
            Assert.That(container[randomIndex], Is.EqualTo(container.Slots.ToArray()[randomIndex]));
        }

        [TestCase(-1)]
        [TestCase(21)]
        public void Index_InvalidIndex_ThrowsIndexOutOfRangeException(int index)
        {
            var randomSize = random.Next(MIN_SIZE_TEST, MAX_SIZE_TEST);
            var container = this.containerFactory.FullContainer(randomSize, this.itemFactory.CreateDefault());

            Assert.That(
                () => container[index], 
                Throws.Exception.With.TypeOf(typeof(IndexOutOfRangeException))
                .And.Message.StartsWith("Index was outside the bounds of the array")
            );
        }
    }
}
