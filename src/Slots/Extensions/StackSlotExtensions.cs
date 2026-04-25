using System.Collections.Generic;
using System.Linq;
using TheChest.Core.Extensions;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Extensions
{
    internal static class StackSlotExtensions
    {
        internal static IStackSlot<T>[] ToStackSlots<T>(this T[] items, int maxStackSize)
        {
            var index = 0;

            var slots = new List<IStackSlot<T>>(items.Length);

            while (index < items.Length)
            {
                var startIndex = index;
                var endIndex = items.GetAdjacentEqualCount(startIndex, maxStackSize) + 1;

                var itemsToAdd = items
                    .Skip(startIndex)
                    .Take(endIndex - startIndex)
                    .ToArray();
                slots.Add(new StackSlot<T>(itemsToAdd, maxStackSize));

                index = endIndex;
            }

            return slots.ToArray();
        }
    }
}
