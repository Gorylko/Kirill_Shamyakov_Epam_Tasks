using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Extensions;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer");

            if(int.TryParse(Console.ReadLine(), out int number) &&
                number > 0)
            {
                Console.Clear();
                Console.WriteLine(GetFirstEvenNaturalNumbers(number).AsString());
            }
            else
            {
                BugReport();
            }

            Console.ReadKey();
        }

        private static IReadOnlyCollection<int> GetFirstEvenNaturalNumbers(int amount)
        {
            if(amount <= 0)
            {
                return null;
            }

            var numberContainer = new List<int>();

            for(int i = 0; i < amount; i++)
            {
                numberContainer.Add((i + 1) * 2);
            }

            return numberContainer;
        }

        private static void BugReport()
        {
            Console.WriteLine("User input is not valid");
        }
    }
}
