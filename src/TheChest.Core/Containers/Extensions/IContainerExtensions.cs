using System;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Extensions;

namespace TheChest.Core.Containers.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IContainer{T}"/>
    /// </summary>
    public static class IContainerExtensions
    {
        /// <summary>
        /// Checks if the container contains an <paramref name="item"/>.
        /// </summary>
        /// <typeparam name="T">Type of item to be checked inside the container</typeparam>
        /// <param name="container"></param>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returns true when the container contains an <paramref name="item"/> in any of its slots</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public static bool Contains<T>(this IContainer<T> container, T item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            
            for (var i = 0; i < container.Size; i++)
            {
                if (container[i].Contains(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the container contains an amount of <paramref name="item"/>.
        /// </summary>
        /// <typeparam name="T">Type of item to be checked inside the container</typeparam>
        /// <param name="container"></param>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount">The minimun amount of <paramref name="item"/> expected</param>
        /// <returns>Returns true when the container contains an <paramref name="amount"/> of <paramref name="item"/> in any of its slots</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> zero or smaller</exception>
        public static bool Contains<T>(this IContainer<T> container, T item, int amount)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            var amountFound = 0;
            for (var i = 0; i < container.Size; i++)
            {
                if (container[i].Contains(item))
                {
                    amountFound++;
                    if (amountFound >= amount)
                        return true;
                }
            }

            return false;
        }
    }
}
