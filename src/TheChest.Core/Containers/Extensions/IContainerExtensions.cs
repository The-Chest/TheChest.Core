using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Extensions;

namespace TheChest.Core.Containers.Extensions
{
    public static class IContainerExtensions
    {
        /// <summary>
        /// Checks if the container contains a item.
        /// </summary>
        /// <typeparam name="T">Type of item to be checked inside the container</typeparam>
        /// <param name="item">Item to be checked</param>
        /// <returns></returns>
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
    }
}
