using System;
using System.Collections.Generic;
using System.Linq;
using Module.Helper;

namespace Task3
{
    public class TaskPerformer //The class violates SOLID, so the name is bad
    {
        public void IncreaseNumbers(ref int number1, ref int number2, ref int number3)
        {
            number1 += 10;
            number2 += 10;
            number3 += 10;
        }

        public void InitializeCircle(double radius, out double circleLength, out double circleArea)
        {
            circleLength = 2 * Math.PI * radius;
            circleArea   = Math.PI * radius * radius;
        }

        public void GetArrayInfo(IEnumerable<int> numbers, out ArrayInfo<int> arrayInfo)
        {
            if(numbers == null)
            {
                arrayInfo = default;
            }

            arrayInfo = new ArrayInfo<int>
            {
                MaxElement = numbers.Max(),
                MinElement = numbers.Min(),
                SumOfAllElements = numbers.Sum()
            };
        }

        public void GetArrayInfo(IEnumerable<double> numbers, out ArrayInfo<double> arrayInfo)
        {
            if (numbers == null)
            {
                arrayInfo = default;
            }

            arrayInfo = new ArrayInfo<double>
            {
                MaxElement = numbers.Max(),
                MinElement = numbers.Min(),
                SumOfAllElements = numbers.Sum()
            };
        }
    }
}
