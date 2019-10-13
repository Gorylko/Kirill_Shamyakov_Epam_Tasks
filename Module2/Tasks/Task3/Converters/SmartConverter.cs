using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3.Converters
{
    public static class SmartConverter
    {
        public static double ConvertToDouble(this string stringNumber)
        {
            if (stringNumber.Contains('.') &&
                Thread.CurrentThread.CurrentCulture.IetfLanguageTag == "ru-RU")
            {
                stringNumber = stringNumber.Replace('.', ',');
            }

            if (double.TryParse(stringNumber, out double number))
            {
                return number;
            }

            return default;
        }
    }
}
