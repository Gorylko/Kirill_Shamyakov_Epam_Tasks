using System;
using Module.Helper;
using Sistim.NedoLinq;
using System.Linq;

namespace Task6
{
    class Program
    {
        private const int IncreaseMagnitude = 11;
        private static bool isValidInput;

        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            do
            {
                Console.Clear();
                var intArrayResult = initializer.GetIntArray();

                if (isValidInput = intArrayResult.IsSuccessful)
                {
                    var intArray = intArrayResult.Value;
                    Console.WriteLine($"Before: {intArray.AsString()}");
                    intArray = intArray.IncreaseAllNumbers(IncreaseMagnitude).ToArray();
                    Console.WriteLine($"After: {intArray.AsString()}");
                }
            } while (!isValidInput);

            Console.ReadKey();
        }
    }
}
