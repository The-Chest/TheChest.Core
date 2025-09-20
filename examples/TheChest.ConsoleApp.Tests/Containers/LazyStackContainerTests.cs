using TheChest.Core.Tests.Containers;

namespace TheChest.ConsoleApp.Tests.Containers
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class LazyStackContainerTests : ILazyStackContainerTests<Item>
    {
        static readonly object[] FixtureArgs = new object[]{
            new object[] {
                new LazyStackContainerFactory<LazyStackContainer, Item>(
                    new LazyStackSlotFactory<LazyStackSlot, Item>()
                ),
                new SlotItemFactory<Item>(),
            }
        };
        public LazyStackContainerTests(ILazyStackContainerFactory<Item> containerFactory, ISlotItemFactory<Item> itemFactory)
            : base(containerFactory, itemFactory)
        {
        }
    }
}
