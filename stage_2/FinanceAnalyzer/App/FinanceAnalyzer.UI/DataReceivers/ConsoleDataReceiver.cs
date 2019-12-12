using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;
using System;
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

            return GetErrorResult<double>();
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

            return GetErrorResult<int>();
        }

        public DataResult<ActionType> GetAction()
        {
            var intResult = GetInt();

            if (intResult.IsSuccessful)
            {
                return new DataResult<ActionType>
                {
                    Value = (ActionType)intResult.Value,
                    IsSuccessful = true
                };
            }

            return GetErrorResult<ActionType>();
        }

        private DataResult<T> GetErrorResult<T>(string errorMessage = "Invalid value of user input")
        {
            return new DataResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
