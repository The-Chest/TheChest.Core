using TheChest.Core.Stack;

namespace TheChest.ConsoleApp.Containers
{
    public class StackSlot : StackSlot<Item>
    {
        public StackSlot(Item[] items) : base(items) { }
        public StackSlot(Item[] items, int maxStack) : base(items, maxStack) { }
    }
}
