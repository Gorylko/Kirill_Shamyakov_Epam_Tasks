namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class DoubleCollectionMapStrategies
    {
        public static IReadOnlyCollection<double> MapDoubleCollection(string source)
        {
            return !string.IsNullOrEmpty(source)
                ? source
                .Split('\n')
                .Where(el => double.TryParse(el, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                .Select(sortedEl => double.Parse(sortedEl))
                .ToArray()
                : null;
        }

        public static IReadOnlyCollection<decimal> MapDecimalCollection(string source)
        {
            return !string.IsNullOrEmpty(source)
                ? source
                .Split('\n')
                .Where(el => decimal.TryParse(el, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
                .Select(sortedEl => decimal.Parse(sortedEl))
                .ToArray()
                : null;
        }
    }
}
