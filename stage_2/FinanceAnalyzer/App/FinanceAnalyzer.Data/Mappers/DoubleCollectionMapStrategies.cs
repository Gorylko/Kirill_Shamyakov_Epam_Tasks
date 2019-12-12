using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FinanceAnalyzer.Data.Mappers
{
    public static class DoubleCollectionMapStrategies
    {
        public static IReadOnlyCollection<double> MapDoubles(string sourse)
        {
            if(sourse == null)
            {
                return default;
            }

            return sourse
                .Split('\n')
                .Where(el => double.TryParse(el, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                .Select(sortedEl => double.Parse(sortedEl))
                .ToArray();
                
        }
    }
}
