namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class DoubleCollectionMapStrategies
    {
        public static IReadOnlyCollection<double> MapDoubleCollection(string source)
        {
            return source != null
                ? source
                .Split('\n')
                .Where(element => double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                .Select(sortedElement => double.Parse(sortedElement))
                .ToArray()
                : null;
        }

        public static IReadOnlyCollection<decimal> MapDecimalCollection(string source)
        {
            return source != null
                ? source
                .Split('\n')
                .Where(element => decimal.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
                .Select(sortedElement => decimal.Parse(sortedElement))
                .ToArray()
                : null;
        }
    }
}
