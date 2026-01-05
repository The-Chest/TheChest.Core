using System.Reflection;

namespace TheChest.Core.Tests.Items
{
    public class ItemFactory<T> : IItemFactory<T>
    {
        public T CreateDefault()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            return (T)instance;
        }

        public T CreateRandom()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            var fields = instance.GetType().GetFields(BindingFlags.NonPublic |BindingFlags.Instance);
            foreach (var field in fields)
            {
                switch (field.FieldType.Name)
                {
                    case "Int32":
                    case "Int64":
                    case "Double":
                    case "Single":
                    case "Decimal":
                    case "Byte":
                    case "Short":
                    case "Long":
                    case "Float":
                        field.SetValue(instance, Random.Shared.Next(1, 1000));
                        break;
                    case "String":
                        field.SetValue(instance, Guid.NewGuid().ToString());
                        break;
                    case "Boolean":
                        field.SetValue(instance, Random.Shared.Next(0, 2) == 1);
                        break;
                    default:
                        throw new NotImplementedException($"Random generation for field type {field.FieldType.Name} is not implemented.");
                }
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
