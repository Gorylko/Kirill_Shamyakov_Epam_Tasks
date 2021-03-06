﻿using Module.Helper.Results;

namespace Task5
{
    public class Calculator
    {
        public CountingResult<int> GetOperationResult(int firstNumber, int secondNumber, MathOperation operationType)
        {
            switch (operationType)
            {
                case MathOperation.Multiplication:
                    return new CountingResult<int> {
                        Params = firstNumber * secondNumber,
                        IsSuccessful = true
                    };
                        
                case MathOperation.Division:
                    return secondNumber == 0 ?
                        GetErrorResult<int>($"Invalid value of {nameof(secondNumber)}, the value of the number was 0") :
                        new CountingResult<int> {
                            Params = firstNumber / secondNumber,
                            IsSuccessful = true
                        };

                case MathOperation.Sum:
                    return new CountingResult<int> {
                        Params = firstNumber + secondNumber,
                        IsSuccessful = true
                    };

                case MathOperation.Difference:
                    return new CountingResult<int>
                    {
                        Params = firstNumber - secondNumber,
                        IsSuccessful = true
                    };

                default:
                    return GetErrorResult<int>("It's impossible!!! Hit the programmer on the head if you see it");
            }
        }

        public CountingResult<double> GetOperationResult(double firstNumber, double secondNumber, MathOperation operationType)
        {
            switch (operationType)
            {
                case MathOperation.Multiplication:
                    return new CountingResult<double>
                    {
                        Params = firstNumber * secondNumber,
                        IsSuccessful = true
                    };

                case MathOperation.Division:
                    return secondNumber == 0 ?
                        GetErrorResult<double>($"Invalid value of {nameof(secondNumber)}, the value of the number was 0") :
                        new CountingResult<double>
                        {
                            Params = firstNumber / secondNumber,
                            IsSuccessful = true
                        };

                case MathOperation.Sum:
                    return new CountingResult<double>
                    {
                        Params = firstNumber + secondNumber,
                        IsSuccessful = true
                    };

                case MathOperation.Difference:
                    return new CountingResult<double>
                    {
                        Params = firstNumber - secondNumber,
                        IsSuccessful = true
                    };

                default:
                    return GetErrorResult<double>("It's impossible!!! Hit the programmer on the head if you see it");
            }
        }

        private CountingResult<T>GetErrorResult<T>(string errorMessage)
        {
            return new CountingResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
