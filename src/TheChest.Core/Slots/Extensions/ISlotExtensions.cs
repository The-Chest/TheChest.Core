using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Extensions
{
    public static class ISlotExtensions
    {
        public static bool Contains<T>(this ISlot<T> slot, T item)
        {
            return slot.Content?.Equals(
                item ?? throw new ArgumentNullException(nameof(item))
            ) ?? false;
        }
    }
}
