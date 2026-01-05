namespace TheChest.Core.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    internal sealed class ReflectionExceptionHandleAttribute : Attribute { }
}
