using Module.Helper;
using System;

namespace Task4
{
    class Program
    {
        private const string Separator = "\no-============================-o\n";

        private static ConsoleDataInitializer initializer { get; set; } = new ConsoleDataInitializer();
        private static TaskPerformer performer { get; set; } = new TaskPerformer();
        private static bool isValidInput;

        static void Main(string[] args)
        {
            CheckCircleInitializer();
            CheckNumberIncreaser();
            CheckArrayInformer();

            Console.ReadKey();
        }

        private static void CheckCircleInitializer()
        {
            do
            {
                var userInputResult = initializer.GetIntNumber();

                if (isValidInput = userInputResult.IsSuccessful)
                {
                    (double circleLength, double circleArea) = performer.InitializeCircle(userInputResult.Value);
                    Console.WriteLine($"Circle length : {circleLength}\n Circle area : {circleArea}{Separator}");
                }
                else
                {
                    BugReport($"Invalid value of {nameof(userInputResult)}");
                }
            } while (!isValidInput);
        }

        private static void CheckNumberIncreaser()
        {
            do
            {
                Console.WriteLine("Enter 3 numbers (press enter after each)");
                if (int.TryParse(Console.ReadLine(), out int number1)
                    && int.TryParse(Console.ReadLine(), out int number2)
                    && int.TryParse(Console.ReadLine(), out int number3))
                {
                    isValidInput = true;
                    Console.WriteLine($"Before : {number1}, {number2}, {number3}");
                    (number1, number2, number3) = performer.IncreaseNumbers((number1, number2, number3));
                    Console.WriteLine($"After : {number1}, {number2}, {number3}{Separator}");
                }
                else
                {
                    isValidInput = false;
                    BugReport("Invalid value of user input");
                }
            } while (!isValidInput);
        }

        private static void CheckArrayInformer()
        {
            do
            {
                var arrayResult = initializer.GetIntArray();
                if (isValidInput = arrayResult.IsSuccessful)
                {
                    (int maxElem, int minElem, int sumOfAllElems) = performer.GetArrayInfo(arrayResult.Value);
                    Console.WriteLine($"Max element : {maxElem}" + "\n" +
                    $"Min element : {minElem}" + "\n" +
                    $"Sum of all elements : {sumOfAllElems}" + "\n");
                }
            } while (!isValidInput);
        }

        private static void BugReport(string additionalInfo)
        {
            Console.WriteLine(additionalInfo);
        }
    }
}
