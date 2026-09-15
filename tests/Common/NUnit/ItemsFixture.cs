using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TheChest.Core.Containers;
using TheChest.Core.Slots;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;

namespace TheChest.Core.Tests.Common.NUnit
{
    internal static class ItemsFixture
    {
        internal static readonly TestFixtureData[] ReferenceTypes =
        {
            new TestFixtureData(typeof(TestItem))
        };

        internal static readonly TestFixtureData[] ValueTypes =
        {
            new TestFixtureData(typeof(TestStructItem)),
            new TestFixtureData(typeof(TestEnumItem))
        };

        internal static readonly TestFixtureData[] All =
        {
            new TestFixtureData(typeof(TestItem)),
            new TestFixtureData(typeof(TestStructItem)),
            new TestFixtureData(typeof(TestEnumItem))
        };
    }
}
