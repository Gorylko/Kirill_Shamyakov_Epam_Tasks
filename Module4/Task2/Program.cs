using Module.Helper;
using Sistim.NedoLinq;
using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            var FirstinitializerResult = initializer.GetIntArray("Enter the first array");
            var SecondinitializerResult = initializer.GetIntArray("Enter the second array");

            if (FirstinitializerResult.IsSuccessful &&
                SecondinitializerResult.IsSuccessful)
            {
                var adder = new MultiAdder();
                Console.WriteLine($"Sum of arrays : {adder.GetSumOfArrays(FirstinitializerResult.Value, SecondinitializerResult.Value).Params.AsString()}");
                Console.WriteLine($"Sum of first array : {adder.SumIntNumbers(FirstinitializerResult.Value).Params}");
                Console.WriteLine($"Sum of first array as string : {adder.JoinStrings("Example", " ", "of", " ", "connected", " ", "strings").Params}");
            }

            Console.ReadKey();
        }
    }
}
