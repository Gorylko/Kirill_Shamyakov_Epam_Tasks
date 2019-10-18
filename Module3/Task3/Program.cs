using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Extensions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer greater than zero");
            if (int.TryParse(Console.ReadLine(), out int number) &&
                number > 0)
            {
                Console.Clear();
                var result = GetFibonacciNums().TakeWhile((el, index) => index < number);

                Console.WriteLine(result.AsString());

            }
            else


            {
                BugReport();
            }

            Console.ReadKey();
        }

        public static IEnumerable<int> GetFibonacciNums()
        {
            int current = 0;
            int next = 1;
            while (true)
            {
                yield return current;
                var temp = next;
                next = current + next;
                current = temp;
            }
        }

        private static void BugReport()
        {
            Console.WriteLine("Invalid user input");
        }
    }
}
