
namespace TheChest.Core.Tests.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal sealed class IgnoreIfReferenceTypeAttribute : TypeConditionAttribute
    {
        protected override bool ShouldIgnore(Type type) => !type.IsValueType;

        protected override string Reason => "Ignored because test does not apply to reference types.";
    }
}
