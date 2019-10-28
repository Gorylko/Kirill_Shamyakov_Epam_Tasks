using System;
using Module.Helper;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            var dataResult = initializer.GetArrayInput();

            if (dataResult.IsSuccessful)
            {
                var array = dataResult.Value;
                Console.WriteLine("Array : " + array.AsString());
                Console.WriteLine("Max : " + array.GetMax());
                Console.WriteLine("Min : " + array.GetMin());
                Console.WriteLine("Sum : " + array.GetSum());
                Console.WriteLine("Difference : " + array.GetDifferenceBetweenMaxAndMin());
                Console.WriteLine("Redo : " + array.GetRedoneCillection().AsString());
            }

            Console.ReadKey();
        }
    }
}
