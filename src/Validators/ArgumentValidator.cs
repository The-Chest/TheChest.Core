using System;
using TheChest.Core.Extensions;

namespace TheChest.Core.Validators
{
    internal static class ArgumentValidator
    {
        #region Positive Validation
        internal static void ThrowIfNotPositive(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }

        internal static void ThrowIfNotPositive(int value, string paramName, string customMessage)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName, customMessage);
        }
        #endregion

        #region Negative Validation
        internal static void ThrowIfNegative(int value, string paramName)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(paramName);
        }

        internal static void ThrowIfNegative(int value, string paramName, string customMessage)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(paramName, customMessage);
        }
        #endregion

        #region Null Validation
        internal static void ThrowIfNull<T>(T[] value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        internal static void ThrowIfNull<T>(T value, string paramName)
        {
            if (value.IsNull())
                throw new ArgumentNullException(paramName);
        }

        internal static void ThrowIfNull<T>(T value, string paramName, string customMessage)
        {
            if (value.IsNull())
                throw new ArgumentNullException(paramName, customMessage);
        }
        #endregion

        #region IndexOutOfRange
        internal static void ThrowIfIndexOutOfRange(int index, int length, string paramName)
        {
            if (index < 0 || index >= length)
                throw new ArgumentOutOfRangeException(paramName);
        }

        internal static void ThrowIfIndexOutOfRange(int index, int length, string paramName, string customMessage)
        {
            if (index < 0 || index >= length)
                throw new ArgumentOutOfRangeException(paramName, index, customMessage);
        }
        #endregion

        
        #region OutOfRange
        internal static void ThrowIfBigger(int value, int range, string paramName)
        {
            if (value > range)
                throw new ArgumentOutOfRangeException(paramName);
        }

        internal static void ThrowIfBigger(int value, int range, string paramName, string customMessage)
        {
            if (value > range)
                throw new ArgumentOutOfRangeException(paramName, value, customMessage);
        }
        #endregion
    }
}