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

                    var multResult = calculator.GetOperationResult(firstResult.Value, secondResult.Value, MathOperation.Multiplication);
                    var divResult = calculator.GetOperationResult(firstResult.Value, secondResult.Value, MathOperation.Division);
                    var sumResult = calculator.GetOperationResult(firstResult.Value, secondResult.Value, MathOperation.Sum);
                    var difResult = calculator.GetOperationResult(firstResult.Value, secondResult.Value, MathOperation.Difference);

                    Console.WriteLine($"Multiplication : {multResult.Params}");
                    Console.WriteLine($"Division : {(divResult.IsSuccessful ? divResult.Params.ToString() : "Can not be divided by zero")}");
                    Console.WriteLine($"Sum : {sumResult.Params}");
                    Console.WriteLine($"Difference : {difResult.Params}");
                }
            } while (!isValidInput);

            Console.WriteLine($"Days in the current month : {GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month)}");
            Console.ReadKey();
        }

        private static int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }
    }
}
