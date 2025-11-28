using TheChest.Core.Slots;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Factories;
using TheChest.Core.Tests.Slots.Interfaces.IStackSlots;

namespace TheChest.Core.Tests.Slots.StackSlotTests 
{
    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class StackSlotTests<T> : IStackSlotTests<T>
    {
        public StackSlotTests() : 
            base(
                (container) =>
                {
                    container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>();
                }
            )
        {
        }
    }
}
