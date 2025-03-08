using TheChest.Core.Containers;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Containers.Factories
{
    public class StackContainerFactory<T, Y> : IStackContainerFactory<Y>
        where T : StackContainer<Y>
    {
        protected readonly IStackSlotFactory<Y> slotFactory;

        public StackContainerFactory(IStackSlotFactory<Y> slotFactory)
        {
            this.slotFactory = slotFactory;
        }

        private static Type GetContainerType()
        {
            var containerType = typeof(T);
            if (!typeof(IStackContainer<Y>).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement IStackContainer<{typeof(Y).Name}>.");
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
                            typeof(IStackSlot<Y>).IsAssignableFrom(parameters[0].ParameterType.GetElementType());
                    })
                    ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a suitable constructor.");

            var slotParameter = constructor.GetParameters().FirstOrDefault(x => x.Name == "slots")
                ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a constructor with IStackSlot<{typeof(Y).Name}>[].");

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(IStackSlot<Y>).IsAssignableFrom(slotType))
            {
                throw new ArgumentException($"Type '{slotType!.FullName}' does not implement IStackSlot<{typeof(Y).Name}>.");
            }

            return slotType;
        }

        public virtual IStackContainer<Y> EmptyContainer(int size = 20)
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
            return (IStackContainer<Y>)container!;
        }

        public virtual IStackContainer<Y> FullContainer(int size, int stackSize, Y item = default)
        {
            var containerType = GetContainerType();
            var slotType = GetSlotTypeFromConstructor();

            Array slots = Array.CreateInstance(slotType, size);
            for (int i = 0; i < size; i++)
            {
                slots.SetValue(slotFactory.WithItem(item, stackSize, stackSize), i);
            }

            var container = Activator.CreateInstance(
                type: containerType,
                args: new object[1] { slots }
            );
            return (IStackContainer<Y>)container!;
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

        public virtual IStackContainer<Y> ShuffledItemsContainer(int size, int stackSize, params Y[] items)
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
                IStackSlot<Y> slot;
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

            return (IStackContainer<Y>)container!;
        }
    }
}
