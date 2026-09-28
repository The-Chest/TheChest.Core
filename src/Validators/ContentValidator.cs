using System;
using System.Collections.Generic;
using System.Linq;

namespace TheChest.Core.Validators
{
    internal static class ContentValidator
    {
        /// <summary>
        /// Validates that array is not <see langword="null"/> and does not exceed the maximum allowed number of elements.
        /// </summary>
        /// <param name="content">The array of contents to validate.</param>
        /// <param name="maxAmount">The maximum number of elements allowed in the <paramref name="content"/> array.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="content"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the length of <paramref name="content"/> exceeds <paramref name="maxAmount"/>.</exception>
        internal static void ValidateContent<T>(IEnumerable<T> content, int maxAmount)
        {
            ArgumentValidator.ThrowIfNull(content, nameof(content));
            ArgumentValidator.ThrowIfBigger(content.Count(), maxAmount, nameof(content), "The content size cannot be bigger than max amount");
        }
    }
}
