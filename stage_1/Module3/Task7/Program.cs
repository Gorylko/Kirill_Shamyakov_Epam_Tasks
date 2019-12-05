using System;
using System.Collections.Generic;

namespace Task7
{
    class Program
    {
        private const int ArrayLength = 10;

        static void Main(string[] args)
        {
            var array = GetRandomArray(ArrayLength);

            LogCollection(array);

            var filteredNumbers = GetBiggerNumbersThanPrevious(array);

            LogCollection(filteredNumbers);

            Console.ReadKey();
        }
        
        private static IEnumerable<int> GetBiggerNumbersThanPrevious(int[] array)
        {
            if(array.Length < 2)
            {
                return default;
            }

            var resultNums = new List<int>();

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    resultNums.Add(array[i + 1]);
                }
            }

            return resultNums;
        }

        private static void LogCollection<T>(IEnumerable<T> collection)
        {
            foreach(var el in collection)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        private static int[] GetRandomArray(int elemCount, int minValue = -100, int maxValue = 101)
        {
            if(elemCount < 1)
            {
                return new int[0];
            }

            var randomTool = new Random();
            var returnArray = new int[elemCount];

            for(int i = 0; i < elemCount; i++)
            {
                returnArray[i] = randomTool.Next(minValue, maxValue);
            }

            return returnArray;
        }
    }
}
