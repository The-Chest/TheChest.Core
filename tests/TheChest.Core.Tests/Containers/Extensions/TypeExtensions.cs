using TheChest.Core.Containers.Interfaces;

namespace TheChest.Core.Tests.Containers.Extensions
{
    internal static class TypeExtensions
    {
        public static Type GetContainerType(this Type containerType, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException(
                    $"'{interfaceType.FullName}' is not an interface."
                );

            if (!interfaceType.IsAssignableFrom(containerType))
                throw new ArgumentException(
                    $"Type '{containerType.FullName}' does not implement '{interfaceType.FullName}'."
                );

            return containerType;
        }

        internal static Type GetContainerType<Container, Item>()
        {
            var containerType = typeof(Container);
            if (!typeof(IStackContainer<Item>).IsAssignableFrom(containerType))
            {
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement IStackContainer<{typeof(Item).Name}>.");
            }

            return containerType;
        }
    }
}
