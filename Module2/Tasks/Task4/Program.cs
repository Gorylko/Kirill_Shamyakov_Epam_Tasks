using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
