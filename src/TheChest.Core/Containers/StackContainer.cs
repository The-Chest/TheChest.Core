using System;
using System.Linq;
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
        /// <summary>
        /// Slots in the Container
        /// </summary>
        protected readonly IStackSlot<T>[] slots;

        /// <inheritdoc/>
        public virtual IStackSlot<T> this[int index] => this.slots[index];

        /// <inheritdoc/>
        public virtual bool IsFull => this.slots.All(x => x.IsFull);

        /// <inheritdoc/>
        public virtual bool IsEmpty => this.slots.All(x => x.IsEmpty);

        /// <inheritdoc/>
        public virtual int Size => this.slots.Length;

        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="IStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackContainer(IStackSlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }
    }
}
