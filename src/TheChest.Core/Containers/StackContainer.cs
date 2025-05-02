using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Generic container with <see cref="IStackContainer{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public class StackContainer<T> : IStackContainer<T>
    {
        public virtual IReadOnlyCollection<IStackSlot<T>> Slots { get; protected set; }

        public virtual IStackSlot<T> this[int index] => Slots.ToArray()[index];

        public virtual bool IsFull => Slots.All(x => x.IsFull);

        public virtual bool IsEmpty => Slots.All(x => x.IsEmpty);

        public virtual int Size => Slots.Count;

        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="IStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackContainer(IStackSlot<T>[] slots)
        {
            Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
