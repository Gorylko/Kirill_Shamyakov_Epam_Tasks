using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var reverser = new NumberReverser();

            while (true)
            {
                Console.WriteLine("Enter the number");

                var userString = Console.ReadLine();

                if (GetDouble(userString, out double parsedDouble))
                {
                    reverser.Reverse(ref parsedDouble);
                    Console.WriteLine(parsedDouble);
                }
                else if (int.TryParse(userString, out int parsedInt))
                {
                    reverser.Reverse(ref parsedInt);
                    Console.WriteLine(parsedInt);
                }
                else
                {
                    BugReport("Input is not a number");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static bool IsValidForDoubleParsing(string stringDouble)
        {
            if (stringDouble == null
                || stringDouble == ""
                || stringDouble.Contains("-,")
                || stringDouble.Contains("-."))
            {
                return false;
            }

            return stringDouble.Where(el => el == ',' || el == '.').Count() == 1 &&
                    !".,".Contains(stringDouble[stringDouble.Length - 1]) &&
                    (!".,".Contains(stringDouble[0]) || !(stringDouble[0] != '-'));
        }

        public static bool GetDouble(string stringInput, out double number)
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

        private static void BugReport(string additionalInformation)
        {
            Console.WriteLine("An application execution error has occurred");
            Console.WriteLine($"Additional Information : {additionalInformation}");
        }
    }
}

