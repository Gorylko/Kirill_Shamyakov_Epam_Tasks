using System;
using Module.Helper;

namespace Task5
{
    class Program
    {
        private static bool isValidInput;

        static void Main(string[] args)
        {
            do
            {
                var initializer = new ConsoleDataInitializer();

                var firstResult = initializer.GetIntNumber("Enter the first int number");
                var secondResult = initializer.GetIntNumber("Enter the second int number");

                if (isValidInput = firstResult.IsSuccessful &&
                    secondResult.IsSuccessful)
                {
                    var calculator = new Calculator();
                    Console.WriteLine();
                }
            } while (!isValidInput);

            Console.ReadKey();
        }

        private static int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }
    }
}
