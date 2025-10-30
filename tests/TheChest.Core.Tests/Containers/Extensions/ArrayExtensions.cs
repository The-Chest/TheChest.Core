namespace TheChest.Core.Tests.Containers.Extensions
{
    internal static class ArrayExtensions
    {
        internal static void Shuffle(this Array items)
        {
            var rng = new Random();
            int n = items.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var item = items.GetValue(n);
                var item2 = items.GetValue(k);

                items.SetValue(item, k);
                items.SetValue(item2, n);
            }
        }
    }
}
