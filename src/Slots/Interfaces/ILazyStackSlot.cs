using TheChest.Core.Components;

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can lazily hold a stack of items of a specified type.
    /// </summary>
    /// <remarks>
    /// <see cref="ILazyStackSlot{T}"/> extends <see cref="ISlot{T}"/>
    /// </remarks>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface ILazyStackSlot<in T> : ISlot<T>, IStackable { }
}
