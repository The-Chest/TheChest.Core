using TheChest.Core;

namespace TheChest.ConsoleApp.Containers
{
    public class Slot : Slot<Item>
    {
        public Slot(Item? currentItem = null) : base(currentItem)
        {
        }
    }
}
