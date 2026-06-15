using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;
using TheChest.Core.Tests.Common.Extensions.Slots;

namespace TheChest.Core.Tests.Common.Extensions.Containers
{
    public static class IStackContainerExtensions
    {
        /// <summary>
        /// Gets the array of slots contained in the specified container.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the slots. </param>
        /// <returns>An array of <see cref="ISlot{T}"/> representing the slots in the container, or <see langword="null"/> if the container does not contain slot data in the expected format.</returns>
        public static IStackSlot<T>[] GetSlots<T>(this IStackContainer<T> container) => container.GetSlotsField() as IStackSlot<T>[];
        /// <summary>
        /// Gets the slot at the specified index from the container's array of slots.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the item.</param>
        /// <param name="index">Index of the slot to retrieve.</param>
        /// <returns>An <see cref="ISlot{T}"/> representing the slot at the specified index in the container, or <see langword="null"/> if the container does not contain slot data in the expected format or if the index is out of bounds.</returns>
        public static IStackSlot<T> GetSlot<T>(this IStackContainer<T> container, int index) => container.GetSlots()[index];
        /// <summary>
        /// Gets the content of the slot at the specified index from the container's array of slots.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the item.</param>
        /// <param name="index">Index of the slot to retrieve.</param>
        /// <returns>An item of type <typeparamref name="T"/> representing the content of the slot at the specified index in the container, or <see langword="null"/> if the container does not contain slot data in the expected format, if the index is out of bounds, or if the slot at the specified index is empty.</returns>
        public static T[] GetItems<T>(this IStackContainer<T> container, int index) => container.GetSlot(index).GetContents();
    }
}
