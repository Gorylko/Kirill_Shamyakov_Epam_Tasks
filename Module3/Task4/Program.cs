using System;
using System.Collections.Generic;
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

                if (IsValidForDoubleParsing(userString))
                {

                    if (double.TryParse(userString, out double parsedDouble))
                    {
                        reverser.Reverse(ref parsedDouble);
                        Console.WriteLine(parsedDouble);
                    }
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

        private static void BugReport(string additionalInformation)
        {
            Console.WriteLine("An application execution error has occurred");
            Console.WriteLine($"Additional Information : {additionalInformation}");
        }
    }
}

