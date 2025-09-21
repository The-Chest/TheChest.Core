using TheChest.Core;

namespace TheChest.ConsoleApp.Containers
{
    public class Container : Container<Item>
    {
        public Container(Slot[] slots) : base(slots) { }
    }
}
