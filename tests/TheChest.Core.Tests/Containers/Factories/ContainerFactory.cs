using TheChest.Core.Containers;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.Factories
{
    public class ContainerFactory<T, Y> : IContainerFactory<Y>
        where T : Container<Y>
    {
        protected readonly ISlotFactory<Y> slotFactory;

        public ContainerFactory(ISlotFactory<Y> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        private static Type GetContainerType()
        {
            var containerType = typeof(T);
            if (!typeof(IContainer<Y>).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement IContainer<{typeof(Y).Name}>.");
            }

            return containerType;
        }

        private static Type GetSlotTypeFromConstructor()
        {
            var containerType = GetContainerType();

            var constructor = containerType.GetConstructors()
                    .FirstOrDefault(ctor =>
                    {
                        var parameters = ctor.GetParameters();
                        return
                            parameters.Length == 1 &&
                            parameters[0].ParameterType.IsArray &&
                            typeof(ISlot<Y>).IsAssignableFrom(parameters[0].ParameterType.GetElementType());
                    })
                    ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a suitable constructor.");

            var slotParameter = constructor.GetParameters().FirstOrDefault(x => x.Name == "slots")
                ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a constructor with ISlot<{typeof(Y).Name}>[].");

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(ISlot<Y>).IsAssignableFrom(slotType))
            {
                throw new ArgumentException($"Type '{slotType!.FullName}' does not implement ISlot<{typeof(Y).Name}>.");
            }

            return slotType;
        }

        public virtual IContainer<Y> EmptyContainer(int size = 20)
        {
            var containerType = GetContainerType();
            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.EmptySlot(), i);
            }

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IContainer<Y>)container!;
        }

        public virtual IContainer<Y> FullContainer(int size, Y item)
        {
            var containerType = GetContainerType();
            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.FullSlot(item), i);
            }

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Y>)container!;
        }

        public virtual IContainer<Y> ShuffledItemContainer(int size, Y item)
        {
            if (item is null)
            {
                throw new ArgumentException("Item cannot be null");
            }

            var containerType = GetContainerType();

            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            var randomIndex = new Random().Next(0, size - 1);
            for (int i = 0; i < size; i++)
            {
                ISlot<Y> slot;
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

            return (IContainer<Y>)container!;
        }

        protected static void ShuffleItems(Array items)
        {
            var rng = new Random();
            int n = items.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var item = items.GetValue(n);
                var item2 = items.GetValue(k);

                items.SetValue(item, k);
                items.SetValue(item2, n);
            }
        }

        public virtual IContainer<Y> ShuffledItemsContainer(int size, params Y[] items)
        {
            if (items.Length > size)
            {
                throw new ArgumentException($"Item amount ({items.Length}) cannot be bigger than the container size ({size})");
            }

            var containerType = GetContainerType();

            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                ISlot<Y> slot;
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
            ShuffleItems(slots);

            var container = Activator.CreateInstance(containerType, slots);

            return (IContainer<Y>)container!;
        }
    }
}
