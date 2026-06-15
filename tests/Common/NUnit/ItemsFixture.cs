using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;

namespace TheChest.Core.Tests.Common.NUnit
{
    internal static class ItemsFixture
    {
        internal static readonly TestFixtureData[] ReferenceTypes =
        {
            new(typeof(TestItem))
        };

        internal static readonly TestFixtureData[] ValueTypes =
        {
            new(typeof(TestStructItem)),
            new(typeof(TestEnumItem))
        };

        internal static readonly TestFixtureData[] All =
        {
            new(typeof(TestItem)),
            new(typeof(TestStructItem)),
            new(typeof(TestEnumItem))
        };
    }
}
