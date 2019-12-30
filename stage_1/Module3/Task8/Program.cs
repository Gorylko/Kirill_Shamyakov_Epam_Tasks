using System;
using Task8.Initializers;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new SpiralArrayInitializer(new int[10, 6]);

            if (!initializer.TryFill())
            {
                BugReport("Invalid value of array");
            }

            Console.ReadKey();
            Console.Clear();

            Func<double, double> function = x => 12 * x * x + 15 * x - 7;

            var provider = new EquationCulculator()
            {
                Function = function,
                LeftBorder = -20,
                RightBorder = 20,
                Accuracy = 0.001
            };

            var providerResult = provider.FindZero();

            if (providerResult.IsSuccessful)
            {
                Console.WriteLine($"x = {providerResult.Value}; f(x) = {function(providerResult.Value)}");
            }
            else
            {
                BugReport(providerResult.ErrorMessage);
            }
            Console.ReadKey();
        }

        private static void BugReport(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine("An error has occurred!!!");
            Console.WriteLine(errorMessage);
        }
    }
}
