using System;

namespace Module_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Enter two numbers (press Enter after each)");

            if (int.TryParse(Console.ReadLine(), out int a) &&
                int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine($"Before magic - a: {a} ## b: {b}");
                Swap(ref a, ref b);
                Console.WriteLine($"After magic - a: {a} ## b: {b}");
            }
            else
            {
                ReportBug();
            }

            Console.ReadKey();
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void ReportBug()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("An error has occurred!!!");
            Console.WriteLine("Finding Crash Causes...");
            Console.WriteLine("The reason for the bug is now looking at the monitor :(");

            Console.ResetColor();
        }
    }
}