using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FinanceAnalyzer.UI.DataReceivers
{
    public class ConsoleDataReceiver : IDataReceiver
    {
        public DataResult<double> GetDouble()
        {
            if(double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                return new DataResult<double>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }

            return GetErrorResult<double>("Invalid value of user input");
        }

        public DataResult<int> GetInt()
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return new DataResult<int>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }

            return GetErrorResult<int>("Invalid value of user input");
        }

        private DataResult<T> GetErrorResult<T>(string errorMessage)
        {
            return new DataResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
