using System;
using Task1.Calculators;
using Task1.DataInitializers;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleTaxDataInitializer();
            var result = initializer.InitializeData();

            if (result.IsSuccessful)
            {
                var calculator = new TaxCalculator(result.Parameters);
                Console.WriteLine(calculator.CalculateTotalTax());
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }

            Console.ReadKey();
        }
    }
}
