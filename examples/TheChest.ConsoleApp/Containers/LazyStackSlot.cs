using TheChest.Core.Stack.Lazy;

namespace TheChest.ConsoleApp.Containers
{
    public class LazyStackSlot : LazyStackSlot<Item>
    {
        public LazyStackSlot(Item currentItem, int amount = 1, int maxStackAmount = 1) : base(currentItem, amount, maxStackAmount)
        {
        }
    }
}
