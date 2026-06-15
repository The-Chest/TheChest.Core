using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Common.Extensions.Slots
{
    public static class ILazyStackSlotExtensions
    {
        /// <summary>
        /// Retrieves the value stored in the specified slot, cast to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the slot's value will be cast and returned.</typeparam>
        /// <param name="slot">The slot from which to retrieve the value. </param>
        /// <returns>The value contained in the slot, cast to type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the slot's underlying field type is not assignable to <typeparamref name="T"/>.</exception>
        public static T GetContent<T>(this ILazyStackSlot<T> slot)
        {
            return slot.GetContentFieldValue<T>();
        }

        /// <summary>
        /// Retrieves a copy of the contents stored in the specified stack slot.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the stack slot.</typeparam>
        /// <param name="slot">The stack slot from which to retrieve the contents.</param>
        /// <returns>A new array containing the elements stored in the stack slot, or <see langword="null"/> if the slot is empty.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the underlying field type of the stack slot is not assignable to an array of type <typeparamref name="T"/>.</exception>
        public static T[] GetContents<T>(this ILazyStackSlot<T> slot)
        {
            var original = slot.GetContentFieldValue<T>();
            if (original is null)
                return Array.Empty<T>();

            return Enumerable.Repeat(original, slot.Amount).ToArray();
        }
    }
}
