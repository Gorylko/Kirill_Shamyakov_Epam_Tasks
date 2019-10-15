using System.Linq;
using System.Threading;

namespace Task3.Converters
{
    public static class SmartConverter
    {
        public static ConvertedResult<double> ConvertToDouble(this string stringNumber)
        {
            if (stringNumber.Contains('.') &&
                Thread.CurrentThread.CurrentCulture.IetfLanguageTag == "ru-RU")
            {
                stringNumber = stringNumber.Replace('.', ',');
            }

            if (double.TryParse(stringNumber, out double number))
            {
                return new ConvertedResult<double>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }

            return GetErrorResult("Invalid value of input");
        }

        private static ConvertedResult<double> GetErrorResult(string errorMessage)
        {
            return new ConvertedResult<double>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
