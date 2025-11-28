namespace TheChest.Core.Tests.Slots.Interfaces.IStackSlots
{
    public partial class IStackSlotTests<T>
    {
        [Test]
        public void ContainsItems_EmptyParams_ReturnsFalse()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var result = slot.Contains(Array.Empty<T>());
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsItems_EmptySlot_ReturnsFalse()
        {
            var slot = this.slotFactory.EmptySlot();
            var result = slot.Contains(Array.Empty<T>());
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsItems_ContainingOnlyOne_ReturnsFalse()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                this.itemFactory.CreateRandom(),
            };
            var result = slot.Contains(items);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsItems_ContainingNoItemsFromParams_ReturnsFalse()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateRandom(),
                this.itemFactory.CreateRandom(),
            };
            var result = slot.Contains(items);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsItems_AllItems_ReturnsTrue()
        {
            var slot = this.slotFactory.FullSlot(this.itemFactory.CreateDefault());
            var items = new T[2]
            {
                this.itemFactory.CreateDefault(),
                this.itemFactory.CreateDefault(),
            };
            var result = slot.Contains(items);
            Assert.That(result, Is.True);
        }
    }
}
