using System;
using TheChest.Core.Extensions;

internal static class ArgumentValidator
{
    internal static void ThrowIfNotPositive(int value, string paramName)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(paramName);
    }

    internal static void ThrowIfNegative(int value, string paramName)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(paramName);
    }

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

    internal static void ThrowIfIndexOutOfRange(int index, int length, string paramName)
    {
        if (index < 0 || index >= length)
            throw new ArgumentOutOfRangeException(paramName);
    }
}