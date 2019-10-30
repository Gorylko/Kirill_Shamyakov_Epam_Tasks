using Module.Helper;
using System;

namespace Task3
{
    class Program
    {
        private const string Separator = "\no-================================-o\n";

        private static ConsoleDataInitializer initializer { get; set; } = new ConsoleDataInitializer();
        private static TaskPerformer performer { get; set; } = new TaskPerformer();
        
        static void Main(string[] args)
        {
            CheckCircleInitializer();
            CheckNumberIncreaser();
            CheckArrayInformer();

            Console.ReadKey();
        }

        private static void CheckCircleInitializer()
        {
            var userInputResult = initializer.GetIntNumber();

            if (!userInputResult.IsSuccessful)
            {
                BugReport($"Invalid value of {nameof(userInputResult)}");
            }
            performer.InitializeCircle(userInputResult.Value, out double circleLength, out double circleArea);
            Console.WriteLine($"Circle length : {circleLength}\n Circle area : {circleArea}{Separator}");
        }

        private static void CheckNumberIncreaser()
        {
            Console.WriteLine("Enter 3 numbers (press enter after each)");
            if (int.TryParse(Console.ReadLine(), out int number1)
                && int.TryParse(Console.ReadLine(), out int number2)
                && int.TryParse(Console.ReadLine(), out int number3))
            {
                Console.WriteLine($"Before : {number1}, {number2}, {number3}");
                performer.IncreaseNumbers(ref number1, ref number2, ref number3);
                Console.WriteLine($"After : {number1}, {number2}, {number3}{Separator}");
            }
            else
            {
                BugReport("Invalid value of user input");
            }
        }

        private static void CheckArrayInformer()
        {
            var arrayResult = initializer.GetIntArray();
            if (arrayResult.IsSuccessful)
            {
                performer.GetArrayInfo(arrayResult.Value, out ArrayInfo<int> info);
                Console.WriteLine(info);
            }
        }

        private static void BugReport(string additionalInfo)
        {
            Console.WriteLine(additionalInfo);
        }
    }
}
