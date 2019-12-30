using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Enter your age )))");
            if(int.TryParse(Console.ReadLine(), out int age) && age > 0)
            {
                if(age % 2 == 0 && age >= 18)
                {
                    Console.WriteLine("Happy Birthday. 18 is a lot, you can walk without a hat");
                }
                else if (age < 18 && 
                         age >= 13 && 
                         age % 2 == 1)
                {
                    Console.WriteLine("Welcome to high school");
                }
                else
                {
                    Console.WriteLine("I have nothing to tell you, come next year");
                }
            }
            else
            {
                BugReport();
            }
            Console.ReadKey();
        }

        private static void BugReport()
        {
            Console.WriteLine("Welcome to kindergarten))0)");
        }
    }
}
