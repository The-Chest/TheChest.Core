using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Common.Extensions.Slots
{
    public static class IStackSlotExtensions
    {
        /// <summary>
        /// Retrieves a copy of the contents stored in the specified stack slot.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the stack slot.</typeparam>
        /// <param name="slot">The stack slot from which to retrieve the contents.</param>
        /// <returns>A new array containing the elements stored in the stack slot, or <see langword="null"/> if the slot is empty.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the underlying field type of the stack slot is not assignable to an array of type <typeparamref name="T"/>.</exception>
        public static T[] GetContents<T>(this IStackSlot<T> slot)
        {
            return slot.GetContentFieldValues<T>();
        }
    }
}
