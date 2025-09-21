﻿using System;
using System.Linq;
using TheChest.Core.Generics.Stack;

namespace TheChest.Core.Stack
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
        public virtual IStackSlot<T> this[int index] => slots[index];

        /// <inheritdoc/>
        public virtual bool IsFull => slots.All(x => x.IsFull);

        /// <inheritdoc/>
        public virtual bool IsEmpty => slots.All(x => x.IsEmpty);

        /// <inheritdoc/>
        public virtual int Size => slots.Length;

        /// <summary>
        /// Creates a Container with <see cref="IStackSlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="IStackSlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StackContainer(IStackSlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i].Contains(item))
                    return true;
            }

            return false;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="amount"/> zero or smaller</exception>
        public bool Contains(T item, int amount)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            var amountFound = 0;
            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i].Contains(item))
                {
                    amountFound++;
                    if (amountFound >= amount)
                        return true;
                }
            }

            return false;
        }
    }
}
