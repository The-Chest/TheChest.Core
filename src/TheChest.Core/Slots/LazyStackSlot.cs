using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Slots
{
    /// <summary>
    /// Slot with with <see cref="IStackSlot{T}"/> implementation which have only one item repeatedly 
    /// </summary>
    /// <typeparam name="T">The item the slot accepts</typeparam>
    public class LazyStackSlot<T> : IStackSlot<T>
    {
        private const string AMOUNT_SMALLER_THAN_ZERO = "The amount property cannot be smaller than zero";
        private const string MAXAMOUNT_SMALLER_THAN_ZERO = "The max amount property cannot be smaller than zero";
        private const string AMOUNT_BIGGER_THAN_MAXAMOUNT = "The item amount cannot be bigger than max amount";

        protected int stackAmount;
        public virtual int StackAmount
        {
            get
            {
                return stackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_SMALLER_THAN_ZERO);

                if (value > maxStackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                stackAmount = value;
            }
        }

        protected int maxStackAmount;
        public virtual int MaxStackAmount
        {
            get
            {
                return maxStackAmount;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), MAXAMOUNT_SMALLER_THAN_ZERO);

                if (value < stackAmount)
                    throw new ArgumentOutOfRangeException(nameof(value), AMOUNT_BIGGER_THAN_MAXAMOUNT);

                maxStackAmount = value;
            }
        }

        public virtual bool IsFull => StackAmount == MaxStackAmount;

        public virtual bool IsEmpty => StackAmount == 0;

        protected readonly ICollection<T> content;
        public virtual T[] Content => content.ToArray();

        /// <summary>
        /// Creates a basic Stack Slot with an amount and max amount
        /// </summary>
        /// <param name="currentItem">The current item to be added</param>
        /// <param name="amount">The amount of <paramref name="currentItem"/> to be added</param>
        /// <param name="maxStackAmount">The maximum permited amount of <paramref name="currentItem"/> to be added</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public LazyStackSlot(T currentItem, int amount = 1, int maxStackAmount = 1)
        {
            if (currentItem == null)
                amount = 0;

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), AMOUNT_SMALLER_THAN_ZERO);
            if (amount > maxStackAmount)
                throw new ArgumentOutOfRangeException(nameof(amount), AMOUNT_BIGGER_THAN_MAXAMOUNT);

            this.content = Enumerable.Repeat(currentItem, amount).ToArray();

            this.maxStackAmount = maxStackAmount;
            this.stackAmount = amount;
        }
    }
}
