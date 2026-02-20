using System.Reflection;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="ISlot{T}"/> interface.
    /// </summary>
    public static class ISlotExtensions
    {
        internal static FieldInfo GetContentField<T>(this ISlot<T> slot)
        {
            var type = slot.GetType();
            var field = type.GetField(
                "content",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy
            ) ??
            throw new InvalidOperationException("Field 'content' not found.");

            return field;
        }

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

            var fieldType = field.FieldType;
            if (fieldType != typeof(T) && !typeof(T).IsAssignableFrom(fieldType))
                throw new InvalidOperationException($"Field type '{fieldType}' is not assignable to '{typeof(T)}'.");

            return (T)field.GetValue(slot);
        }

        /// <summary>
        /// Retrieves a copy of the contents stored in the specified stack slot.
        /// </summary>
        /// <typeparam name="T">The type of elements contained in the stack slot.</typeparam>
        /// <param name="slot">The stack slot from which to retrieve the contents.</param>
        /// <returns>A new array containing the elements stored in the stack slot, or <see langword="null"/> if the slot is empty.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the underlying field type of the stack slot is not assignable to an array of type <typeparamref name="T"/>.</exception>
        public static T[] GetContents<T>(this IStackSlot<T> slot)
        {
            var field = slot.GetContentField();

            var fieldType = field.FieldType;
            if (fieldType != typeof(T[]) && !typeof(T[]).IsAssignableFrom(fieldType))
                throw new InvalidOperationException($"Field type '{fieldType}' is not assignable to '{typeof(T[])}'.");

            var original = (T[])field.GetValue(slot);
            if (original is null)
                return null;

            return (T[])original.Clone();
        }
    }
}
