using System.Collections.Generic;
using System.Text;

namespace Task3.Extensions
{
    public static class CollectionExtensions
    {
        public static string AsString(this IEnumerable<int> collection)
        {
            if (collection == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            foreach (var el in collection)
            {
                stringBuilder.Append(el.ToString() + " ");
            }

            return stringBuilder.ToString();
        }
    }
}
