using TheChest.Core.Components;

namespace TheChest.Core.Slots.Interfaces
{
    /// <summary>
    /// Represents a slot that can hold a stack of items, providing information about the current and maximum number of items.
    /// </summary>
    /// <remarks> 
    /// <see cref="IStackSlot{T}"/> extends <see cref="ISlot{T}"/>
    /// </remarks>
    /// <typeparam name="T">The type of item the slot can hold</typeparam>
    public interface IStackSlot<in T> : IContentState, IStackable {  }
}
