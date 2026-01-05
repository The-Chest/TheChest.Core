using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Slots.Interfaces.ISlotTests;

namespace TheChest.Core.Tests.Slots.SlotTests
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class SlotTests<T> : ISlotTests<T>
    {
        public SlotTests() : base(
            container => container.Register<ISlotFactory<T>, SlotFactory<Slot<T>,T>>()
        ) { }
    }
}
