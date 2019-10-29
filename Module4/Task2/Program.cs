using Module.Helper;
using Sistim.NedoLinq;
using System;

namespace Task2
{
    class Program
    {
        private static MultiAdder _adder { get; set; } = new MultiAdder();
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            var FirstinitializerResult = initializer.GetIntArray();
            var SecondinitializerResult = initializer.GetIntArray();

            if (FirstinitializerResult.IsSuccessful &&
                SecondinitializerResult.IsSuccessful)
            {
                Console.WriteLine($"Sum of arrays : {_adder.GetSumOfArrays(FirstinitializerResult.Value, SecondinitializerResult.Value).Params.AsString()}");
                Console.WriteLine($"Sum of first array : {_adder.SumIntNumbers(FirstinitializerResult.Value).Params}");
                Console.WriteLine($"Sum of first array as string : {_adder.JoinStrings("Example", " ", "of", " ", "connected", " ", "strings").Params}");
            }
            
            Console.ReadKey();
        }
    }
}
