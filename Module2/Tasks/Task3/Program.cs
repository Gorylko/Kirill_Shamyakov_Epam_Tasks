using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Task3.Converters;

namespace Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            var firstNumberResult = Console.ReadLine().ConvertToDouble();

            Console.WriteLine("Enter second number");
            var secondNumberResult = Console.ReadLine().ConvertToDouble();

            if(firstNumberResult.IsSuccessful &&
              secondNumberResult.IsSuccessful)
            {
                var firstNumber = firstNumberResult.Value;
                var secondNumber = secondNumberResult.Value;

                Console.WriteLine($"Before magic - a: {firstNumber} ## b: {secondNumber}");

                Swap<double>(ref firstNumber, ref secondNumber);

                Console.WriteLine($"After magic - a: {firstNumber} ## b: {secondNumber}");
            }
            else
            {
                ReportBug();
            }

            Console.ReadKey();
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        private static void ReportBug()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("An error has occurred!!!");
            Console.WriteLine("Finding Crash Causes...");
            Console.WriteLine("The reason for the bug is now looking at the monitor :(");

            Console.ResetColor();
        }
    }
}