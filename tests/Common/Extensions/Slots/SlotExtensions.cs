using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheChest.Core.Tests.Common.Extensions.Slots
{
    internal static class SlotExtensions
    {        
        //TODO: add to TheChest.Tests.Common.Extensions
        internal static Type GetSlotTypeByConstructor<TSlotInterface>(this Type containerType, string slotParameterName = "slots")
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
                ?? throw new ArgumentException($"Container type '{containerType.FullName}' does not have a constructor with {typeof(TSlotInterface).Name}[].");

            var slotType = slotParameter.ParameterType.GetElementType();
            if (!typeof(TSlotInterface).IsAssignableFrom(slotType))
                throw new ArgumentException($"Type '{slotType?.FullName}' does not implement {typeof(TSlotInterface).FullName}.");

            return slotType!;
        }

        internal static FieldInfo GetContentField(this object slot)
        {
            var type = slot.GetType();

            while (type != null)
            {
                var field = type.GetField(
                    "content",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );

                if (field != null)
                    return field;

                type = type.BaseType;
            }

            throw new InvalidOperationException("Field 'content' not found.");
        }

        internal static T GetContentFieldValue<T>(this object slot)
        {
            var field = slot.GetContentField();

            var value = field.GetValue(slot);
            if (value is null)
                return default!;

            return (T)value;
        }

        internal static T[] GetContentFieldValues<T>(this object slot)
        {
            var field = slot.GetContentField();

            var original = field.GetValue(slot);
            if (original is null)
                return Array.Empty<T>();

            var array = original as object[];
            if (array is null)
                return Array.Empty<T>();

            return array.Where(x => x is not null).Cast<T>().ToArray();
        }
    }
}
