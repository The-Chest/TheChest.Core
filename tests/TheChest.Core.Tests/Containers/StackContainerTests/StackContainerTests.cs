using TheChest.Core.Tests.Containers.Factories;
using TheChest.Core.Tests.Items.Classes;
using TheChest.Core.Tests.Items.Structs;
using TheChest.Core.Tests.Slots.Factories;

namespace TheChest.Core.Tests.Containers.StackContainerTests
{

    [TestFixture(typeof(TestItem))]
    [TestFixture(typeof(TestStructItem))]
    public partial class StackContainerTests<T> : IStackContainerTests<T>
    {
        public StackContainerTests() :
            base(
                container => {
                    container.Register<IStackSlotFactory<T>, StackSlotFactory<StackSlot<T>, T>>();
                    container.Register<IStackContainerFactory<T>, StackContainerFactory<StackContainer<T>, T>>();
                }
            ) 
        { }
    }
}
