using System.Reflection;

namespace TheChest.Core.Tests.Slots.Factories
{
    public class SlotItemFactory<T> : ISlotItemFactory<T>
    {
        public T CreateDefault()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            return (T)instance;
        }

        public T CreateRandom()
        {
            var type = typeof(T);
            var instance = (T)Activator.CreateInstance(type);

            //TODO: extract this logic to another class for other types of values
            var fields = instance.GetType().GetFields(BindingFlags.NonPublic |BindingFlags.Instance);
            foreach (var field in fields) { 
                field.SetValue(instance, Guid.NewGuid().ToString());
            }
            return instance;
        }

        public T[] CreateMany(int amount)
        {
            return Enumerable.Repeat(CreateDefault(), amount).ToArray();
        }

        public T[] CreateManyRandom(int amount)
        {
            return Enumerable.Repeat(CreateRandom(), amount).ToArray();
        }
    }
}
