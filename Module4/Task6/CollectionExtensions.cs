using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    public static class CollectionExtensions
    {
        private static void IncreaseAllNumbers(this IEnumerable<int> numberCollection, int amount)
        {
            numberCollection = numberCollection.Select(el => el + amount);
        }

        private static void IncreaseAllNumbers(this IEnumerable<double> numberCollection, double amount)
        {
            numberCollection = numberCollection.Select(el => el + amount);
        }
    }
}
