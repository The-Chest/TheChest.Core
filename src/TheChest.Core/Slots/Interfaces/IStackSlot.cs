using System.Collections.Generic;

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Generic Container Slot with item stack
    /// </summary>
    /// <typeparam name="T">Item the Slot Accept</typeparam>
    public interface IStackSlot<T> : ISlot<IReadOnlyCollection<T>>
    {
        /// <summary>
        /// Defines the amount of items this slot is holding
        /// </summary>
        int StackAmount { get; }

        /// <summary>
        /// Defines the max amount of item that this slot can contain
        /// </summary>
        int MaxStackAmount { get; }
    }
}
