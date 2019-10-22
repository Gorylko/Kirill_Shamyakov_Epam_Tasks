using System;
using Task4.Parsers;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var reverser = new NumberReverser();

            Console.WriteLine("Enter the number");

            var userString = Console.ReadLine();

            if (DoubleParser.TryParse(userString, out double parsedDouble))
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
        }

        private static void BugReport(string additionalInformation)
        {
            Console.WriteLine("An application execution error has occurred");
            Console.WriteLine($"Additional Information : {additionalInformation}");
        }
    }
}

