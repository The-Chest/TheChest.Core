using TheChest.Core.Containers;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Containers.Extensions;
using TheChest.Core.Tests.Containers.Interfaces.Factories;

namespace TheChest.Core.Tests.Containers.Implementations.Factories
{
    public class StackContainerFactory<Container, Item> : IStackContainerFactory<Item>
        where Container : StackContainer<Item>
    {
        protected readonly IStackSlotFactory<Item> slotFactory;

        public StackContainerFactory(IStackSlotFactory<Item> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        public virtual IStackContainer<Item> EmptyContainer(int size = 20)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<IStackSlot<Item>>();

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
            return (IStackContainer<Item>)container!;
        }

        public virtual IStackContainer<Item> FullContainer(int size, int stackSize, Item item = default!)
        {
            var containerType = typeof(Container).GetContainerType(typeof(IStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<IStackSlot<Item>>();

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

            return (IStackContainer<Item>)container!;
        }

        public virtual IStackContainer<Item> ShuffledItemsContainer(int size, int stackSize, params Item[] items)
        {
            if (items.Length > size)
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");
            
            var containerType = typeof(Container).GetContainerType(typeof(IStackContainer<Item>));
            var slotType = containerType.GetSlotTypeByConstructor<IStackSlot<Item>>();

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

            return (IStackContainer<Item>)container!;
        }
    }
}
