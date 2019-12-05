using System.Globalization;
using System.Linq;

namespace Task4.Parsers
{
    class DoubleParser
    {
        private static bool IsValidForDoubleParsing(string stringDouble)
        {
            if (stringDouble == null
                || stringDouble == ""
                || stringDouble.Contains("-,")
                || stringDouble.Contains("-."))
            {
                return false;
            }

            return stringDouble.Where(el => el == ',' || el == '.').Count() == 1 
                && !".,".Contains(stringDouble[stringDouble.Length - 1]) 
                &&(!".,".Contains(stringDouble[0]) || !(stringDouble[0] != '-'));
        }

        public static bool TryParse(string stringInput, out double number)
        {

            number = default;
            if (!IsValidForDoubleParsing(stringInput))
            {
                return false;
            }
            if (
                !double.TryParse(stringInput, NumberStyles.Any, CultureInfo.CurrentCulture, out number) &&
                !double.TryParse(stringInput, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out number) &&
                !double.TryParse(stringInput, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
            {
                return false;
            }
            return true;
        }
    }
}
