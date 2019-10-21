using System;
using Task4.Calculators;
using Task4.DataInitializers;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();
            var initializedResult = initializer.InitializeData();

            if (initializedResult.IsSuccessful)
            {
                var calculator = new GeometricCalculator(initializedResult.Parameters.GeneralArea);
                Console.WriteLine(calculator.GetFullInfo());
            }
            else
            {
                Console.WriteLine(initializedResult.ErrorMessage);
            }

            Console.ReadKey();
        }
    }
}
