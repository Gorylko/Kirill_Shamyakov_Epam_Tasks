using System;
using Task7.Sorters;
using Module.Helper;
using Sistim.NedoLinq;

namespace Task7
{
    class Program
    {
        private static bool isValidInput;

        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            do {
                var result = initializer.GetIntArray();
                if(isValidInput = result.IsSuccessful)
                {
                    var array = result.Value;
                    array = (int[])array.Sort();

                    Console.WriteLine($"Sorted array(default) : {array.AsString()}");

                    Console.WriteLine($"Sorted array(reversed) : {array.Sort(SortWay.Descending).AsString()}");
                }
            } while (!isValidInput);

            Console.ReadKey();
        }
    }
}
