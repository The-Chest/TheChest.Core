using System;

namespace TheChest.Core.Validators
{
    internal static class IndexValidator
    {
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
    }
}
