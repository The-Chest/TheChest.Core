using System;
using System.Linq;
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
        /// <summary>
        /// Slots in the Container
        /// </summary>
        protected ISlot<T>[] slots;

        /// <inheritdoc/>
        public virtual ISlot<T> this[int index] => this.slots[index];

        /// <inheritdoc/>
        public virtual int Size => this.slots.Length;

        /// <inheritdoc/>
        public virtual bool IsFull => this.slots.All(x => x.IsFull);

        /// <inheritdoc/>
        public virtual bool IsEmpty => this.slots.All(x => x.IsEmpty);

        /// <summary>
        /// Creates a Container with <see cref="ISlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ISlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Container(ISlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
