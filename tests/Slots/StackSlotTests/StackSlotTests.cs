using TheChest.Core.Tests.Common.Items.ReferenceType;
using TheChest.Core.Tests.Common.Items.ValueType;
using TheChest.Core.Tests.Factories.Slots;
using TheChest.Core.Tests.Factories.Slots.Interfaces;
using TheChest.Core.Tests.Slots.Interfaces.IStackSlotTests;

namespace TheChest.Core.Tests.Slots.StackSlotTests 
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class StackSlotTests<T> : IStackSlotTests<T>
    {
        public StackSlotTests() : base(
            container => container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>()
        ) { }
    }
}
