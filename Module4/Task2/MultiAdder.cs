using Module.Helper.Results;
using System;
using System.Collections.Generic;
using Sistim.NedoLinq;

namespace Task2
{
    public class MultiAdder
    {
        public CountingResult<int> SumIntNumbers(params int[] numbers)
        {
            if(numbers == null)
            {
                return GetErrorResult<int>($"Invalid value of {nameof(numbers)}");
            }

            try
            {
                return new CountingResult<int>
                {
                    Params = checked(numbers.Sum()),
                    IsSuccessful = true
                };
                
            }
            catch (OverflowException)
            {
                return GetErrorResult<int>("Integer overflow occurred");
            }
        }

        public CountingResult<double> SumDoubleNumbers(params double[] numbers)
        {
            if (numbers == null)
            {
                return GetErrorResult<double>($"Invalid value of {nameof(numbers)}");
            }

            try
            {
                return new CountingResult<double>
                {
                    Params = checked(numbers.Sum()),
                    IsSuccessful = true
                };

            }
            catch (OverflowException)
            {
                return GetErrorResult<double>("Integer overflow occurred");
            }
        }
        
        public CountingResult<string> JoinStrings(params string[] strings)
        {
            if(strings == null)
            {
                return GetErrorResult<string>($"Invalid value of {nameof(strings)}");
            }

            return new CountingResult<string>
            {
                Params = string.Join(" ", strings),
                IsSuccessful = true
            };
        }

        public CountingResult<int[]> GetSumOfArrays(int[] firstArray, int[] secondArray)
        {
            if(firstArray == null || secondArray == null)
            {
                return GetErrorResult<int[]>($"Invalid value of arrays(or array)");
            }

            var resultArray = new int[
                firstArray.Length > secondArray.Length ? 
                firstArray.Length : 
                secondArray.Length];

            for (int i = 0; i < ((firstArray.Length < secondArray.Length) ? firstArray.Length : secondArray.Length); i++)
            {
                resultArray[i] = firstArray[i] + secondArray[i];
            }

            for (int i = ((firstArray.Length < secondArray.Length) ? firstArray.Length : secondArray.Length); i < resultArray.Length; i++)
            {
                resultArray[i] = ((firstArray.Length < secondArray.Length) ? secondArray[i] : firstArray[i]);
            }

            return new CountingResult<int[]>
            {
                Params = resultArray,
                IsSuccessful = true
            };
        }

        private CountingResult<T> GetErrorResult<T>(string errorMessage)
        {
            return new CountingResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
