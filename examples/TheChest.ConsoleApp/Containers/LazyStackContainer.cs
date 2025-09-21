using TheChest.Core.Stack.Lazy;

namespace TheChest.ConsoleApp.Containers
{
    public class LazyStackContainer : LazyStackContainer<Item>
    {
        public LazyStackContainer(LazyStackSlot[] slots) : base(slots)
        {
        }
    }
}
