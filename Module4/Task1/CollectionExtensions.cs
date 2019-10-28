using System.Collections.Generic;
using Sistim.NedoLinq;
using System.Text;

namespace Task1
{
    public static class CollectionExtensions
    {
        public static IEnumerable<int> GetRedoneCillection(this IEnumerable<int> collection)
        {
            var maxElement = collection.Max();
            var minElement = collection.Min();

            return collection.Select(element => element % 2 == 0 ?
            element + maxElement : 
            element - minElement);
        }

        public static int GetMax(this IEnumerable<int> collection)
        {
            return collection.Max();
        }

        public static int GetMin(this IEnumerable<int> collection)
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

        public static string AsString<T>(this IEnumerable<T> collection)
        {
            var builder = new StringBuilder();

            foreach(var elem in collection)
            {
                builder.Append(elem + " ");
            }
            return builder.ToString();
        }
    }
}
