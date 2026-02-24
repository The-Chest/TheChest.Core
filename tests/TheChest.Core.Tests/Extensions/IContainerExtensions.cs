using System.Reflection;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Extensions
{
    /// <summary>
    /// Provides extension methods for accessing internal fields of <see cref="IContainer{T}"/> instances.
    /// </summary>
    public static class IContainerExtensions
    {
        /// <summary>
        /// Retrieves the value of the non-public or public instance field named "slots" from the specified container.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the <paramref name="container"/>.</typeparam>
        /// <param name="container">The container object from which to retrieve the "slots" field value.</param>
        /// <returns>The value of the "slots" field from the specified container.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the "slots" field does not exist on the container's type.</exception>
        internal static object GetSlotsField<T>(this IContainer<T> container)
        {
            var type = container.GetType();

            var field = type.GetField(
                "slots",
                BindingFlags.Instance | BindingFlags.NonPublic | 
                BindingFlags.Public | BindingFlags.FlattenHierarchy
            ) ?? throw new InvalidOperationException("Field 'slots' not found.");

            return field.GetValue(container);
        }
        /// <summary>
        /// Gets the array of slots contained in the specified container.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the slots. </param>
        /// <returns>An array of <see cref="ISlot{T}"/> representing the slots in the container, or <see langword="null"/> if the container does not contain slot data in the expected format.</returns>
        public static ISlot<T>[] GetSlots<T>(this IContainer<T> container) => container.GetSlotsField() as ISlot<T>[];
        /// <summary>
        /// Gets the slot at the specified index from the container's array of slots.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the item.</param>
        /// <param name="index">Index of the slot to retrieve.</param>
        /// <returns>An <see cref="ISlot{T}"/> representing the slot at the specified index in the container, or <see langword="null"/> if the container does not contain slot data in the expected format or if the index is out of bounds.</returns>
        public static ISlot<T> GetSlot<T>(this IContainer<T> container, int index) => container.GetSlots()[index];
        /// <summary>
        /// Gets the content of the slot at the specified index from the container's array of slots.
        /// </summary>
        /// <typeparam name="T">The type of items stored in the slots.</typeparam>
        /// <param name="container">The container from which to retrieve the item.</param>
        /// <param name="index">Index of the slot to retrieve.</param>
        /// <returns>An item of type <typeparamref name="T"/> representing the content of the slot at the specified index in the container, or <see langword="null"/> if the container does not contain slot data in the expected format, if the index is out of bounds, or if the slot at the specified index is empty.</returns>
        public static T GetItem<T>(this IContainer<T> container, int index) => container.GetSlots()[index].GetContent();
    }
}
