using Module.Helper;
using System;

namespace Task3
{
    class Program
    {
        private const string Separator = "\no-================================-o\n";

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
                    performer.InitializeCircle(userInputResult.Value, out double circleLength, out double circleArea);
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
                    performer.IncreaseNumbers(ref number1, ref number2, ref number3);
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
                    performer.GetArrayInfo(arrayResult.Value, out ArrayInfo<int> info);
                    Console.WriteLine(info);
                }
            } while (!isValidInput);
        }

        private static void BugReport(string additionalInfo)
        {
            Console.WriteLine(additionalInfo);
        }
    }
}
