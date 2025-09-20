using System;
using System.Linq;
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Containers
{
    /// <summary>
    /// Generic container with <see cref="ILazyStackContainer{T}"/> implementation
    /// </summary>
    /// <typeparam name="T">An item type</typeparam>
    public class LazyStackContainer<T> : ILazyStackContainer<T>
    {
        /// <summary>
        /// Slots in the Container
        /// </summary>
        protected readonly ILazyStackSlot<T>[] slots;

        /// <summary>
        /// Creates a Container with <see cref="ILazyStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ILazyStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LazyStackContainer(ILazyStackSlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }

        /// <inheritdoc/>
        public ILazyStackSlot<T> this[int index] => this.slots[index];
        /// <inheritdoc/>
        public virtual int Size => this.slots.Length;
        /// <inheritdoc/>
        public virtual bool IsFull => this.slots.All(x => x.IsFull);
        /// <inheritdoc/>
        public virtual bool IsEmpty => this.slots.All(x => x.IsEmpty);
    }
}
