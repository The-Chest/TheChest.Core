using System.Reflection;

namespace TheChest.Core.Tests.Common.Extensions.Containers
{
    internal static class ContainerExtensions
    {
        //TODO: add to TheChest.Tests.Common.Extensions
        internal static Type GetContainerType(this Type containerType, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException($"'{interfaceType.FullName}' is not an interface.");

            if (!interfaceType.IsAssignableFrom(containerType))
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement '{interfaceType.FullName}'.");

            return containerType;
        }

        /// <summary>
        /// Retrieves the value of the non-public or public instance field named "slots" from the specified container.
        /// </summary>
        /// <param name="container">The container object from which to retrieve the "slots" field value.</param>
        /// <returns>The value of the "slots" field from the specified container.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the "slots" field does not exist on the container's type.</exception>
        internal static object? GetSlotsField(this object container)
        {
            var type = container.GetType();

            var field = type.GetField(
                "slots",
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public | BindingFlags.FlattenHierarchy
            ) ?? throw new InvalidOperationException("Field 'slots' not found.");

            return field.GetValue(container);
        }
    }
}
