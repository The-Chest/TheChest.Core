using System;
using System.Reflection;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Common.Extensions.Slots
{
    /// <summary>
    /// Provides extension methods for the slots.
    /// </summary>
    public static class ISlotExtensions
    {
        /// <summary>
        /// Retrieves the value stored in the specified slot, cast to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the slot's value will be cast and returned.</typeparam>
        /// <param name="slot">The slot from which to retrieve the value. </param>
        /// <returns>The value contained in the slot, cast to type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the slot's underlying field type is not assignable to <typeparamref name="T"/>.</exception>
        public static T GetContent<T>(this ISlot<T> slot)
        {
            var field = slot.GetContentField();

            var value = field.GetValue(slot);
            if (value is null)
                return default!;

            return (T)value;
        }
    }
}
