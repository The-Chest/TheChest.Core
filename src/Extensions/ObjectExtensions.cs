namespace TheChest.Core.Extensions
{
    internal static class ObjectExtensions
    {
        internal static bool IsNull<T>(this T obj)
        {
            if(typeof(T).IsValueType)
                return false;//Has no nullable in value types, so it can't be null

            return (object)obj is null;
        }
    }
}
