using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    [Category("Slot")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class SlotTests<T> : BaseTest<T>
    {
        protected readonly ISlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        public SlotTests() : base(
            container => container.Register<ISlotFactory<T>, SlotFactory<Slot<T>,T>>()
        )
        {
            this.slotFactory = this.configurations.Resolve<ISlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }
    }
}
