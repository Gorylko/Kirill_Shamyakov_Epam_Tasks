using System;

namespace Task8
{
    class Program
    {
        private static bool isValidInput;

        static void Main(string[] args)
        {
            Func<double, double> function = x => 12 * x * x + 15 * x - 7;

            var provider = new EquationCalculator()
            {
                Function = function,
                LeftBorder = -20,
                RightBorder = 20,
                Accuracy = 0.001
            };

            var providerResult = provider.FindZero();

            if (providerResult.IsSuccessful)
            {
                Console.WriteLine($"x = {providerResult.Params}; f(x) = {function(providerResult.Params)}");
            }

            Console.ReadKey();
        }
    }
}
