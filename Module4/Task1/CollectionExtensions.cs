using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public static class CollectionExtensions
    {
        public static void RedoCollection(this IEnumerable<int> collection)
        {
            collection = collection.Select(element => element % 2 == 0 ?
            element + collection.Max() : 
            element - collection.Min());
        }

        public static T GetMax<T>(this IEnumerable<T> collection)
        {
            return collection.Max();
        }

        public static T GetMin<T>(this IEnumerable<T> collection)
        {
            return collection.Min();
        }

        public static int GetSum(this IEnumerable<int> collection)
        {
            return collection.Sum();
        }

        public static double GetSum(this IEnumerable<double> collection)
        {
            return collection.Sum();
        }

        public static int GetDifferenceBetweenMaxAndMin(this IEnumerable<int> collection)
        {
            return collection.Max() - collection.Min();
        }
        
        public static double GetDifferenceBetweenMaxAndMin(this IEnumerable<double> collection)
        {
            return collection.Max() - collection.Min();
        }
    }
}
