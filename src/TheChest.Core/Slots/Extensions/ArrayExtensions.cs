using System;

namespace TheChest.Core.Slots.Extensions
{
    internal static class ArrayExtensions
    {
        /// <summary>
        /// Removes any <see langword="null"/> values from the input array and returns a new array containing only the non-null items in a generic array.
        /// </summary>
        /// <param name="array">The array to be normalized.</param>
        /// <returns>A new array containing only the non-null items from the input array.</returns>
        /// <exception cref="ArgumentNullException">When the input array is <see langword="null"/>.</exception>
        internal static T[] ToGenericArray<T>(this object[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            
            var result = new T[array.Length];
            var index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (!(item is null))
                {
                    result[index++] = (T)item;
                }
            }
            Array.Resize(ref result, index);
            
            return result;
        }

        /// <summary>
        /// Removes any <see langword="null"/> values from the input array and returns a new array containing only the non-null items in an object array.
        /// </summary>
        /// <param name="array">The array to be normalized.</param>
        /// <returns>A new array containing only the non-null items from the input array.</returns>
        /// <exception cref="ArgumentNullException">When the input array is <see langword="null"/>.</exception>
        internal static object[] ToObjectArray<T>(this T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var result = new object[array.Length];
            var index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (!(item is null))
                {
                    result[index++] = item;
                }
            }
            Array.Resize(ref result, index);
            
            return result;
        }
    }
}
