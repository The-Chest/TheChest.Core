using System;

namespace TheChest.Core.Validators
{
    internal static class AmountValidator
    {
        internal static void ValidateAmount(int amount, int maxAmount)
        {
            ArgumentValidator.ThrowIfNegative(amount, nameof(amount), "The amount cannot be smaller than zero");
            ArgumentValidator.ThrowIfNegative(maxAmount, nameof(maxAmount), "The max amount cannot be smaller than zero");
            ArgumentValidator.ThrowIfBigger(amount, maxAmount, nameof(amount), "The amount cannot be bigger than max amount");
        }
    }
}
