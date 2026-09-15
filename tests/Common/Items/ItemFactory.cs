using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TheChest.Core.Tests.Common.Items.Interfaces;

namespace TheChest.Core.Tests.Common.Items
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

        public T CreateDifferentFrom(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            var type = typeof(T);

            if (type.IsEnum)
            {
                foreach (T value in type.GetEnumValues())
                {
                    if (!comparer.Equals(value, item))
                        return value;
                }

                throw new InvalidOperationException($"Enum type {type.FullName} has no value different from the provided item");
            }

            if (type == typeof(bool))
                return (T)(object)!(bool)(object)item!;

            const int maxAttempts = 100;
            for (var attempts = 0; attempts < maxAttempts; attempts++)
            {
                var randomItem = this.CreateRandom();

                if (!comparer.Equals(randomItem, item))
                    return randomItem;
            }

            throw new InvalidOperationException($"Could not create an item different from the provided {type.FullName} value after {maxAttempts} attempts");
        }

        public T CreateRandom()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type) ??
                throw new InvalidOperationException($"Could not create instance of type {type.FullName}");

            var instanceType = instance.GetType();
            if(instanceType.IsEnum || instanceType.IsPrimitive)
            {
                if (instanceType.IsEnum)
                {
                    var values = ((T[])instanceType.GetEnumValues()).Skip(1).ToArray();
                    return (T)values.GetValue(0)!;
                }
                return SetRandomValue<T>(instanceType);
            }

            var fields = instanceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                field.SetValue(instance, ItemFactory<T>.SetRandomValue<dynamic>(field.FieldType));
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

        private static Y SetRandomValue<Y>(Type type)
        {
            return type switch
            {
                #if NET6_0_OR_GREATER
                var t when t == typeof(int)
                    => (Y)(object)Random.Shared.Next(1, 1000),

                var t when t == typeof(long)
                    => (Y)(object)Random.Shared.NextInt64(1, 1000),

                var t when t == typeof(double)
                    => (Y)(object)(Random.Shared.NextDouble() * 1000),

                var t when t == typeof(float)
                    => (Y)(object)(float)(Random.Shared.NextDouble() * 1000),

                var t when t == typeof(decimal)
                    => (Y)(object)(decimal)(Random.Shared.NextDouble() * 1000),

                var t when t == typeof(byte)
                    => (Y)(object)(byte)Random.Shared.Next(1, 255),

                var t when t == typeof(string)
                    => (Y)(object)Guid.NewGuid().ToString(),

                var t when t == typeof(bool)
                    => (Y)(object)(Random.Shared.Next(0, 2) == 1),
#else
                var t when t == typeof(int) || t == typeof(long)
                    => (Y)(object)new Random().Next(1, 1000),

                var t when t == typeof(double)
                    => (Y)(object)(new Random().NextDouble() * 1000),

                var t when t == typeof(float)
                    => (Y)(object)(float)(new Random().NextDouble() * 1000),

                var t when t == typeof(decimal)
                    => (Y)(object)(decimal)(new Random().NextDouble() * 1000),

                var t when t == typeof(byte)
                    => (Y)(object)(byte)new Random().Next(1, 255),

                var t when t == typeof(string)
                    => (Y)(object)Guid.NewGuid().ToString(),

                var t when t == typeof(bool)
                    => (Y)(object)(new Random().Next(0, 2) == 1),
#endif
                _ => throw new NotImplementedException($"Random generation for type {typeof(Y).Name} is not implemented.")
            };
        }
    }
}
