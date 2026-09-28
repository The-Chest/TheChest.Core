using System;

namespace TheChest.Core.Validators
{
    internal static class AmountValidator
    {
        internal static void ValidateAmount(int amount, int maxAmount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(amount),
                    actualValue: amount,
                    message: "The amount cannot be smaller than zero"
                );
            if (maxAmount < 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(maxAmount),
                    actualValue: maxAmount,
                    message: "The max amount cannot be smaller than zero"
                );
            if (amount > maxAmount)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(amount),
                    actualValue: amount,
                    message: "The item amount cannot be bigger than max amount"
                );
        }
    }
}
