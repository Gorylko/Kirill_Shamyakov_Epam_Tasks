using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.Helper;

namespace Task4
{
    class Program
    {
        private const string Separator = "\no-============================-o\n";

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
            (double circleLength, double circleArea) = performer.InitializeCircle(userInputResult.Value);
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
                (number1, number2, number3) = performer.IncreaseNumbers(number1, number2, number3);
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
                (int maxElem, int minElem, int sumOfAllElems) = performer.GetArrayInfo(arrayResult.Value);
                Console.WriteLine($"Max element : {maxElem}" + "\n" +
                $"Min element : {minElem}" + "\n" +
                $"Sum of all elements : {sumOfAllElems}" + "\n");
            }
        }

        private static void BugReport(string additionalInfo)
        {
            Console.WriteLine(additionalInfo);
        }
    }
}
