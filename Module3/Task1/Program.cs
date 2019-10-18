using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Enter two int numbers (press Enter after each)");

            if (int.TryParse(Console.ReadLine(), out int firstNumber) &&
                int.TryParse(Console.ReadLine(), out int secondNumber))
            {
                Console.WriteLine($"Result: {Multiply(firstNumber, secondNumber)}");
            }
            else
            {
                ReportBug();
            }
            Console.ReadKey();
        }

        private static int Multiply(int firstNum, int secondNum)
        {
            return (int)(firstNum / (1 / (double)secondNum)); //without multiplication 
        }

        static void ReportBug()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("User input isn't valid!!!");

            Console.ResetColor();
        }
    }
}
