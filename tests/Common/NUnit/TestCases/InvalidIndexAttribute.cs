using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;

namespace TheChest.Core.Tests.Common.NUnit.TestCases
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class InvalidIndexAttribute : NUnitAttribute, ITestBuilder
    {
        private readonly int maxIndex;

        public InvalidIndexAttribute(int maxIndex)
        {
            this.maxIndex = maxIndex;
        }

        public IEnumerable<TestMethod> BuildFrom(
            IMethodInfo method,
            Test? suite
        )
        {
            var builder = new NUnitTestCaseBuilder();

            yield return builder.BuildTestMethod(
                method,
                suite,
                new TestCaseParameters(new object[] { -1 })
            );

            yield return builder.BuildTestMethod(
                method,
                suite,
                new TestCaseParameters(new object[] { this.maxIndex })
            );
        }
    }
}
