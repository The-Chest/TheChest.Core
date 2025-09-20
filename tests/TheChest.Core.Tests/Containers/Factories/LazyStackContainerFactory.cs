using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Containers.Extensions;

namespace TheChest.Core.Tests.Containers.Factories
{
    public class LazyStackContainerFactory<Container, Item> : ILazyStackContainerFactory<Item>
        where Container : ILazyStackContainer<Item>
    {
        protected readonly ILazyStackSlotFactory<Item> slotFactory;

        public LazyStackContainerFactory(ILazyStackSlotFactory<Item> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        public virtual ILazyStackContainer<Item> EmptyContainer(int size = 20)
        {
            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    slotFactory: _ => slotFactory.EmptySlot(),
                    shuffle: true
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (ILazyStackContainer<Item>)container!;
        }

        public virtual ILazyStackContainer<Item> FullContainer(int size, int stackSize, Item item = default!)
        {
            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    slotFactory: _ => slotFactory.WithItem(item, stackSize, stackSize),
                    shuffle: true
                );
            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (ILazyStackContainer<Item>)container!;
        }

        public virtual ILazyStackContainer<Item> ShuffledItemsContainer(int size, int stackSize, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");

            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    slotFactory:
                        i => i < items.Length
                            ? slotFactory.FullSlot(items[i])
                            : slotFactory.EmptySlot(),
                    shuffle: true
                );

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (ILazyStackContainer<Item>)container!;
        }
    }
}
