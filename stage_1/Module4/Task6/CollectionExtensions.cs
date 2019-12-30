using System.Collections.Generic;
using Sistim.NedoLinq;

namespace Task6
{
    public static class CollectionExtensions
    {
        public static IEnumerable<int> IncreaseAllNumbers(this IEnumerable<int> numberCollection, int amount)
        {
            return numberCollection.Select(el => el + amount);
        }

        public static IEnumerable<double> IncreaseAllNumbers(this IEnumerable<double> numberCollection, double amount)
        {
            return numberCollection.Select(el => el + amount);
        }
    }
}
