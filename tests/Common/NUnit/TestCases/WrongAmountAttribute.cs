namespace TheChest.Core.Tests.Common.NUnit.TestCases
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal sealed class WrongAmountAttribute : TestCaseSourceAttribute
    {
        public WrongAmountAttribute() : base(typeof(WrongAmountAttribute), nameof(Cases)) { }
        public static IEnumerable<int> Cases
        {
            get
            {
                yield return 0;
                yield return -1;
            }
        }
    }
}
