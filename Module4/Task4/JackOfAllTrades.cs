using System;
using System.Collections.Generic;
using System.Linq;
using Module.Helper;

namespace Task4
{
    public class JackOfAllTrades
    {
        public void IncreaseNumbers(ref int number1, ref int number2, ref int number3)
        {
            number1 += 10;
            number2 += 10;
            number3 += 10;
        }

        public (double, double) InitializeCircle(double radius)
        {
            var circleLength = 2 * Math.PI * radius;
            var circleArea = Math.PI * radius * radius;

            return (circleLength, circleArea);
        }

        public (int, int, int) GetArrayInfo(IEnumerable<int> numbers)
        {
            if (numbers == null)
            {
                 return default;
            }

            var MaxElement = numbers.Max();
            var MinElement = numbers.Min();
            var SumOfAllElements = numbers.Sum();

            return (MaxElement, MinElement, SumOfAllElements);
        }

        public (double, double, double) GetArrayInfo(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                return default;
            }

            var MaxElement = numbers.Max();
            var MinElement = numbers.Min();
            var SumOfAllElements = numbers.Sum();

            return (MaxElement, MinElement, SumOfAllElements);
        }
    }
}
