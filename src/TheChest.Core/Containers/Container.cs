using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Generic container with <see cref="IContainer{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public class Container<T> : IContainer<T>
    {
        public virtual IReadOnlyCollection<ISlot<T>> Slots
        {
            get;
            protected set;
        }

        public virtual ISlot<T> this[int index] => Slots.ToArray()[index];

        public virtual int Size => Slots.Count;

        public virtual bool IsFull => Slots.All(x => x.IsFull);

        public virtual bool IsEmpty => Slots.All(x => x.IsEmpty);

        /// <summary>
        /// Creates a Container with <see cref="ISlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ISlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Container(ISlot<T>[] slots)
        {
            Slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
