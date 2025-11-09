using System.Reflection;
using TheChest.Core.Tests.Items.Interfaces;

namespace TheChest.Core.Tests.Items
{
    public class ItemFactory<T> : IItemFactory<T>
    {
        public T CreateDefault()
        {
            var type = typeof(T);
            var instance = 
                Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            return (T)instance;
        }

        public T CreateRandom()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            var fields = instance.GetType().GetFields(BindingFlags.NonPublic |BindingFlags.Instance);
            foreach (var field in fields) { 
                field.SetValue(instance, Guid.NewGuid().ToString());
            }
            return (T)instance;
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
