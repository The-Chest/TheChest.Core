using System.Collections.Generic;
using TheChest.Core.Components;

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can hold item.
    /// </summary>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface ISlot<out T> : IContentState, IEnumerable<T> { }
}
