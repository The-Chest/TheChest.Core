namespace TheChest.Core.Tests.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class IgnoreIfPrimitiveTypeAttribute : TypeConditionAttribute
    {
        protected override bool ShouldIgnore(Type type) => !type.IsPrimitive;

        protected override string Reason => "Ignored because test does not apply to primitive types.";
    }
}
