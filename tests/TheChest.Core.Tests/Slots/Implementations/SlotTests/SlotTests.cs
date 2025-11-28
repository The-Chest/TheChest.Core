using TheChest.Core.Slots;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Implementations.Factories;
using TheChest.Core.Tests.Slots.Interfaces.ISlots;

namespace TheChest.Core.Tests.Slots.Implementations.Slots
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class SlotTests<T> : ISlotTests<T>
    {
        public SlotTests() : base(
            container =>
            {
                container.Register<ISlotFactory<T>, SlotFactory<Slot<T>,T>>();
            }
        ) { }
    }
}
