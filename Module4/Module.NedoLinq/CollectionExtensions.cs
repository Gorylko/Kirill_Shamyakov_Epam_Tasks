using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistim.NedoLinq
{
    public static partial class Enumerable
    {
        public static int Max(this IEnumerable<int> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            int maxElem;
            using (IEnumerator<int> enumerator = collection.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception("collection is empty");
                }

                maxElem = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    int currentElement = enumerator.Current;
                    if (currentElement > maxElem)
                    {
                        maxElem = currentElement;
                    }
                }
            }

            return maxElem;
        }

        public static double Max(this IEnumerable<double> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            double max;
            using (IEnumerator<double> enumerator = collection.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception("collection is empty");
                }

                max = enumerator.Current;

                while (double.IsNaN(max))
                {
                    if (!enumerator.MoveNext())
                    {
                        return max;
                    }

                    max = enumerator.Current;
                }

                while (enumerator.MoveNext())
                {
                    double x = enumerator.Current;
                    if (x > max)
                    {
                        max = x;
                    }
                }
            }

            return max;
        }

        public static int Min(this IEnumerable<int> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            int min;
            using (IEnumerator<int> enumerator = collection.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception("collection is empty");
                }

                min = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    int currentElement = enumerator.Current;
                    if (currentElement < min)
                    {
                        min = currentElement;
                    }
                }
            }

            return min;
        }

        public static double Min(this IEnumerable<double> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            double min;
            using (IEnumerator<double> enumerator = collection.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception("collection is empty");
                }

                min = enumerator.Current;
                if (double.IsNaN(min))
                {
                    return min;
                }

                while (enumerator.MoveNext())
                {
                    double currenElement = enumerator.Current;
                    if (currenElement < min)
                    {
                        min = currenElement;
                    }
                    else if (double.IsNaN(currenElement))
                    {
                        return currenElement;
                    }
                }
            }

            return min;
        }

        public static int Sum(this IEnumerable<int> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            int returnSum = 0;
            checked
            {
                foreach (int element in collection)
                {
                    returnSum += element;
                }
            }

            return returnSum;
        }

        public static double Sum(this IEnumerable<double> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            double returnSum = 0;
            checked
            {
                foreach (double element in collection)
                {
                    returnSum += element;
                }
            }

            return returnSum;
        }

        public static IEnumerable<TResult> Select<TCollection, TResult>(
        this IEnumerable<TCollection> collection, Func<TCollection, TResult> selector)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            var list = new List<TResult>(collection.Count());

            foreach(var el in collection)
            {
                list.Add(selector(el));
            }

            return list;
        }

        public static string AsString<T>(this IEnumerable<T> collection)
        {
            var builder = new StringBuilder();

            foreach (var elem in collection)
            {
                builder.Append(elem + " ");
            }
            return builder.ToString();
        }

    }
}
