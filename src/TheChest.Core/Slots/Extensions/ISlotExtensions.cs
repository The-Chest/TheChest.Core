using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Extensions
{
    public static class ISlotExtensions
    {
        /// <summary>
        /// Checks if the slot contains the item.
        /// </summary>
        /// <typeparam name="T">Type of item to be checked inside the slot</typeparam>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returns true if <paramref name="item"/> is equal to <see cref="ISlot{T}.Content"/> and both are not null</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public static bool Contains<T>(this ISlot<T> slot, T item)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));

            if(slot.IsEmpty) 
                return false;
            
            return slot.Content!.Equals(item);
        }
    }
}
