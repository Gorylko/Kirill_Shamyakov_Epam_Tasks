using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Sorters
{
    public static class CollectionSorter
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> collection, SortWay way = SortWay.Ascending)
        {
            if (collection == null)
            {
                return null;
            }

            return way == SortWay.Ascending ? 
                collection.OrderBy(el => el).ToArray() : 
                collection.OrderBy(el => el).Reverse().ToArray();
        }
    }
}
