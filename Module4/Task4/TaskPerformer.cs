using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public class TaskPerformer //The class violates SOLID, so the name is bad
    {
        public (int, int, int) IncreaseNumbers((int number1, int number2, int number3) numbers)
        {
            return (numbers.number1 + 10, numbers.number2 + 10, numbers.number3 + 10);
        }

        public (double, double) InitializeCircle(double radius)
        {
            var circleLength = 2 * Math.PI * radius;
            var circleArea = Math.PI * radius * radius;

            return (circleLength, circleArea);
        }

        public (int max, int min, int sum) GetArrayInfo(IEnumerable<int> numbers)
        {
            if (numbers == null)
            {
                return default;
            }

            return (numbers.Max(), numbers.Min(), numbers.Sum());
        }

        public (double max, double min, double sum) GetArrayInfo(IEnumerable<double> numbers)
        {
            if (numbers == null)
            {
                return default;
            }

            return (numbers.Max(), numbers.Min(), numbers.Sum());
        }
    }
}
