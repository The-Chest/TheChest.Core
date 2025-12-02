using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace TheChest.Core.Tests.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal abstract class TypeConditionAttribute : NUnitAttribute, IApplyToTest
    {
        protected abstract bool ShouldIgnore(Type type);

        protected virtual string Reason => "Condition not met.";

        public void ApplyToTest(Test test)
        {
            var fixtureType = test.TypeInfo?.Type;
            if (fixtureType == null)
                return;

            if (!fixtureType.IsGenericType)
                return;

            var t = fixtureType.GetGenericArguments()[0];

            if (this.ShouldIgnore(t))
            {
                test.RunState = RunState.Ignored;
            }
        }
    }
}
