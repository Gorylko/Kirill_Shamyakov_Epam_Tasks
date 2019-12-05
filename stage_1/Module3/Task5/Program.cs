using System;
using Task5.Initializers;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new UserInputInitializer();
            var userResult = initializer.InitializeData();

            if (userResult.IsSuccessful)
            {
                var number = userResult.Parameters.Number;
                number = number.RemoveNumber(userResult.Parameters.NumberToDelete);

                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(userResult.ErrorMessage);
            }

            Console.ReadKey();
        }
    }
}
