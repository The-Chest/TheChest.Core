using System.Collections.Generic;
using TheChest.Core.Abstractions;

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can lazily hold a stack of items of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface ILazyStackSlot<out T> : IContentState, IStackable, IEnumerable<IEnumerable<T>> { }
}
