using System;
using System.Collections.Generic;
using Module.Helper;
using Sistim.NedoLinq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            var dataResult = initializer.GetIntArray();

            if (dataResult.IsSuccessful)
            {
                var array = dataResult.Value;
                GetFullInfo(array);
            }

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
