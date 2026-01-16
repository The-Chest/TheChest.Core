using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
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

        public virtual IContainer<Item> Empty(int size = 20)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: _ => slotFactory.EmptySlot(),
                    shuffle: true
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> Full(int size, Item item)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: _ => slotFactory.FullSlot(item),
                    shuffle: true
                );
            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> WithItemShuffled(int size, Item item)
        {
            if (item is null)
                throw new ArgumentException("Item cannot be null");

            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            var randomIndex = new Random().Next(0, size - 1);
            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: 
                        i => i == randomIndex
                            ? slotFactory.FullSlot(item)
                            : slotFactory.EmptySlot(),
                    shuffle: true
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> WithItemsShuffled(int size, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");

            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: i => i < items.Length ? slotFactory.FullSlot(items[i]) : slotFactory.EmptySlot(),
                    shuffle: true
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (IContainer<Item>)container!;
        }

        public virtual IContainer<Item> WithItems(int size, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");
            
            var containerType = typeof(Container).GetContainerType(typeof(IContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ISlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: i => i < items.Length ? slotFactory.FullSlot(items[i]) : slotFactory.EmptySlot(),
                    shuffle: false
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IContainer<Item>)container!;
        }
    }
}
