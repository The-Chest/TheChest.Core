﻿namespace TheChest.Core.Inventories.Tests.Containers
{
    public partial class InventoryTests<T>
    {
        [Test]
        public void GetAll_WithItems_ReturnsSearchingItem()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateItems(size / 2);
            var sameItems = this.itemFactory.CreateItems(size / 2);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items.Concat(sameItems).ToArray());

            var index = this.random.Next(0, size);
            var randomItem = items[index];
            var result = inventory.GetAll(randomItem);
        
            Assert.That(result, Is.EqualTo(sameItems));
        }

        [Test]
        public void GetAll_WithItems_RemovesFromFoundSlots()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateItems(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var index = this.random.Next(0, size);
            var randomItem = items[index];
            inventory.GetAll(randomItem);

            Assert.That(inventory[index].IsEmpty, Is.True);
        }

        [Test]
        public void GetAll_NonExistingItem_ReturnsEmptyArray()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateItems(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);

            var randomItem = this.itemFactory.CreateItem();
            var result = inventory.GetAll(randomItem);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetAll_NonExistingItem_DoNotRemovesFromAnySlots()
        {
            var size = this.random.Next(10, 20);
            var items = this.itemFactory.CreateItems(size);
            var inventory = this.containerFactory.ShuffledItemsContainer(size, items);
            var slots = inventory.Slots.ToArray();

            var randomItem = this.itemFactory.CreateItem();
            inventory.GetAll(randomItem);

            Assert.That(inventory.Slots, Is.EqualTo(slots));
        }
    }
}
