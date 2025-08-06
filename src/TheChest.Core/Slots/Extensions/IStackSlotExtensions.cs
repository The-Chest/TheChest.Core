using System;
using System.Linq;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IStackSlot{T}"/> interface
    /// </summary>
    public static class IStackSlotExtensions
    {
        /// <summary>
        /// Checks if the slot contains an amount of the item.
        /// </summary>
        /// <typeparam name="T">Type of item to be checked inside the slot</typeparam>
        /// <param name="slot"></param>
        /// <param name="item">Item to be checked</param>
        /// <param name="amount">Minimum amount of <paramref name="item"/> expected</param>
        /// <returns>Returns true if <paramref name="item"/> is contained inside the Content</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> zero or smaller</exception>
        public static bool Contains<T>(this IStackSlot<T> slot, T item, int amount = 1)
        {
            item = item ?? throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (slot.IsEmpty)
                return false;

            return slot.Content!.AsEnumerable().Contains(item) && slot.StackAmount >= amount;
        }
    }
}
