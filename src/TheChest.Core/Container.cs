﻿using System;
using System.Linq;
using TheChest.Core.Generics;

namespace TheChest.Core
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
        protected readonly ISlot<T>[] slots;

        /// <inheritdoc/>
        public virtual ISlot<T> this[int index] => slots[index];

        /// <inheritdoc/>
        public virtual int Size => slots.Length;

        /// <inheritdoc/>
        public virtual bool IsFull => slots.All(x => x.IsFull);

        /// <inheritdoc/>
        public virtual bool IsEmpty => slots.All(x => x.IsEmpty);

        /// <summary>
        /// Creates a Container with <see cref="ISlot{T}"/> implementation
        /// </summary>
        /// <param name="slots">An array of <see cref="ISlot{T}"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Container(ISlot<T>[] slots)
        {
            this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">When <paramref name="item"/> is null</exception>
        public virtual bool Contains(T item)
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
        public virtual bool Contains(T item, int amount)
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
