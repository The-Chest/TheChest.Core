using System.Reflection;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Extensions;
using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Slots.Factories.Interfaces;

namespace TheChest.Core.Tests.Containers.Extensions
{
    internal static class TypeExtensions
    {
        internal static Type GetContainerType(
            this Type containerType, 
            Type interfaceType
        )
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException(
                    $"'{interfaceType.FullName}' is not an interface."
                );

            if (!interfaceType.IsAssignableFrom(containerType))
                throw new ArgumentException(
                    $"Type '{containerType.FullName}' does not implement '{interfaceType.FullName}'."
                );

            return containerType;
        }

        internal static Type GetSlotTypeByConstructor<TSlotInterface>(
            this Type containerType,
            string slotParameterName = "slots"
        )
        {
            var constructor = containerType.GetConstructors()
                    .FirstOrDefault(ctor =>
                    {
                        var parameters = ctor.GetParameters();
                        var slotParamType = parameters.Length > 0 ? parameters[0].ParameterType : null;
                            if (slotParamType is null)
                                return false;
                        return
                            parameters.Length == 1 &&
                            slotParamType.IsArray &&
                            typeof(TSlotInterface).IsAssignableFrom(slotParamType.GetElementType());
                    })
                    ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a suitable constructor.");

            var slotParameter = constructor.GetParameters().FirstOrDefault(x => x.Name == slotParameterName)
                ?? throw new ArgumentException(
                    $"Container type '{containerType.FullName}' does not have a constructor with {typeof(TSlotInterface).Name}[]."
                );

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(TSlotInterface).IsAssignableFrom(slotType))
            {
                throw new ArgumentException(
                    $"Type '{slotType?.FullName}' does not implement {typeof(TSlotInterface).FullName}."
                );
            }

            return slotType!;
        }

        internal static Array CreateSlots<Item>(
            this Type slotType,
            int size, 
            Func<int, ISlot<Item>> slotFactory,
            bool shuffle = false
        )
        {
            var slots = Array.CreateInstance(slotType, size);

            for (int i = 0; i < size; i++)
            {
                var slot = slotFactory(i);
                slots.SetValue(slot, i);
            }

            if (shuffle)
                slots.Shuffle();

            return slots;
        }
    }
}
