using System;
using System.Collections.Generic;
using TheChest.Core.Extensions;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots.Extensions
{
    internal static class StackSlotExtensions
    {
        internal static IStackSlot<T>[] ToStackSlots<T>(this T[] items, int maxStackSize)
        {
            if (maxStackSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxStackSize), "Max stack size must be greater than zero.");

            var index = 0;

            var slots = new List<IStackSlot<T>>((items.Length + maxStackSize - 1) / maxStackSize);

            while (index < items.Length)
            {
                var startIndex = index;
                var endIndex = Math.Min(
                    items.GetAdjacentEqualCount(startIndex, maxStackSize) + 1,
                    items.Length
                );

                var amountToAdd = endIndex - startIndex;
                var itemsToAdd = new T[amountToAdd];

                Array.Copy(
                    items, startIndex, 
                    itemsToAdd, 0, amountToAdd
                );
                slots.Add(new StackSlot<T>(itemsToAdd, maxStackSize));

                index = endIndex;
            }

            return slots.ToArray();
        }
    }
}
