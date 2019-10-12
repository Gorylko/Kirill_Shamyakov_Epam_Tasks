using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Task3.Entities;

namespace Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            double firstNumber = Console.ReadLine().ConvertToDouble();

            Console.WriteLine("");
            double secondNumber = Console.ReadLine().ConvertToDouble();

            //Console.WriteLine($"Before magic - a: {a} ## b: {b}");
            Swap(ref firstNumber, ref secondNumber);
            //Console.WriteLine($"After magic - a: {a} ## b: {b}");
            ReportBug();

            Console.ReadKey();
        }

        private static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
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