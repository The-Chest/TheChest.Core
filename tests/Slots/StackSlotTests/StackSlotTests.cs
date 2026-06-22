using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.StackSlotTests
{
    [Category("StackSlot")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class StackSlotTests<T> : BaseTest<T>
    {
        protected readonly IStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_STACK_SIZE_TEST = 5;
        protected const int MAX_STACK_SIZE_TEST = 10;

        public StackSlotTests() : base(container => 
        {
            container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>(); 
        })
        {
            this.slotFactory = this.configurations.Resolve<IStackSlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }

        protected int GenerateStackSize() => this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
    }
}
