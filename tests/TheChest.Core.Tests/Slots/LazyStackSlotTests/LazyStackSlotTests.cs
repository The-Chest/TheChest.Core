using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Slots.Interfaces.ILazyStackSlotTests;

namespace TheChest.Core.Tests.Slots.LazyStackSlotTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    [TestFixture(typeof(TestEnumItem))]
    public partial class LazyStackSlotTests<T> : ILazyStackSlotTests<T>
    {
        public LazyStackSlotTests() : base(
            container => container.Register<ILazyStackSlotFactory<T>, LazyStackSlotFactory<LazyStackSlot<T>, T>>()
        ) { }
    }
}
