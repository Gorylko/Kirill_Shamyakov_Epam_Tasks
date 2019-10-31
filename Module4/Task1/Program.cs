using System;
using System.Collections.Generic;
using Module.Helper;
using Sistim.NedoLinq;

namespace Task1
{
    class Program
    {
        private static bool isValidInput;

        static void Main(string[] args)
        {
            do
            {
                var initializer = new ConsoleDataInitializer();

                var dataResult = initializer.GetIntArray();

                if (isValidInput = dataResult.IsSuccessful)
                {
                    var array = dataResult.Value;
                    GetFullInfo(array);
                }
            } while (!isValidInput);

            Console.ReadKey();
        }

        private static void GetFullInfo(IEnumerable<int> collection)
        {
            Console.WriteLine("Array : " + collection.AsString());
            Console.WriteLine("Max : " + collection.GetMax());
            Console.WriteLine("Min : " + collection.GetMin());
            Console.WriteLine("Sum : " + collection.GetSum());
            Console.WriteLine("Difference : " + collection.GetDifferenceBetweenMaxAndMin());
            Console.WriteLine("Redo : " + collection.GetRedoneCillection().AsString());
        }
    }
}
