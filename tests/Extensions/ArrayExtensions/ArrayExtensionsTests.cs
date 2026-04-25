using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;

namespace TheChest.Core.Tests.Extensions
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class ArrayExtensionsTests<T> : BaseTest<T>
    {
        private readonly IItemFactory<T> itemFactory;

        public ArrayExtensionsTests() : base(_ => { })
        {
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}
