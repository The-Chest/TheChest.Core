using TheChest.Core.Containers;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Containers.Extensions;
using TheChest.Core.Tests.Extensions;

namespace TheChest.Core.Tests.Containers.Factories
{
    public class ContainerFactory<Container, Item> : IContainerFactory<Item>
        where Container : Container<Item>
    {
        protected readonly ISlotFactory<Item> slotFactory;

        public ContainerFactory(ISlotFactory<Item> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        public virtual IContainer<Item> EmptyContainer(int size = 20)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.EmptySlot(), i);
            }

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> FullContainer(int size, Item item)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.FullSlot(item), i);
            }

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> ShuffledItemContainer(int size, Item item)
        {
            if (item is null)
                throw new ArgumentException("Item cannot be null");

            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            Array slots = Array.CreateInstance(slotType, size);
            var randomIndex = new Random().Next(0, size - 1);
            for (int i = 0; i < size; i++)
            {
                ISlot<Item> slot;
                if (i == randomIndex)
                {
                    slot = slotFactory.FullSlot(item);
                }
                else
                {
                    slot = slotFactory.EmptySlot();
                }

                slots.SetValue(slot, i);
            }

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> ShuffledItemsContainer(int size, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");

            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                ISlot<Item> slot;
                if (i < items.Length)
                {
                    slot = slotFactory.FullSlot(items[i]);
                }
                else
                {
                    slot = slotFactory.EmptySlot();
                }

                slots.SetValue(slot, i);
            }
            slots.Shuffle();

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Item>)container!;
        }
    }
}
