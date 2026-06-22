using TheChest.Core.Tests.Common.Configurations;
using TheChest.Core.Tests.Common.Items.Interfaces;
using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    [Category("LazyStackSlot")]
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class LazyStackSlotTests<T> : BaseTest<T>
    {
        protected readonly ILazyStackSlotFactory<T> slotFactory;
        protected readonly IItemFactory<T> itemFactory;

        protected const int MIN_STACK_SIZE_TEST = 5;
        protected const int MAX_STACK_SIZE_TEST = 10;

        public LazyStackSlotTests() : base(container => 
        {
            container.Register<ILazyStackSlotFactory<T>, LazyStackSlotFactory<LazyStackSlot<T>, T>>(); 
        })
        {
            this.slotFactory = this.configurations.Resolve<ILazyStackSlotFactory<T>>();
            this.itemFactory = this.configurations.Resolve<IItemFactory<T>>();
        }

        protected int GenerateStackSize() => this.random.Next(MIN_STACK_SIZE_TEST, MAX_STACK_SIZE_TEST);
    }
}
