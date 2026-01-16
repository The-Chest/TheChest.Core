using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Extensions;

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

        public virtual ILazyStackContainer<Item> Empty(int size = 20)
        {
            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

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
            return (ILazyStackContainer<Item>)container!;
        }

        public virtual ILazyStackContainer<Item> Full(int size, int stackSize, Item item = default!)
        {
            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory: _ => slotFactory.WithItem(item, stackSize, stackSize),
                    shuffle: true
                );
            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );

            return (ILazyStackContainer<Item>)container!;
        }

        public virtual ILazyStackContainer<Item> ShuffledItems(int size, int stackSize, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");

            var containerType = typeof(Container).GetContainerType(typeof(ILazyStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<ILazyStackSlot<Item>>();

            var slots = slotType
                .CreateSlots(
                    size: size,
                    factory:
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
