using TheChest.Core.Slots;
using TheChest.Core.Slots.Interfaces;

namespace TheChest.Core.Tests.Slots.Factories
{
    public class SlotFactory<T, Y> : ISlotFactory<Y> where T : Slot<Y>
    {
        public virtual ISlot<Y> EmptySlot()
        {
            var type = typeof(T);
            var slot = Activator.CreateInstance(type, default(Y));
            return (ISlot<Y>)slot!;
        }

        public virtual ISlot<Y> FullSlot(Y item)
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(new Type[1] { typeof(Y?) });
            var slot = constructor!.Invoke(new object[1] { item });
            return (ISlot<Y>)slot;
        }
    }
}
