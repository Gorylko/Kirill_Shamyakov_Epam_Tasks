using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;
using FinanceAnalyzer.UI.Interfaces;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI.DataReceivers
{
    public class ConsoleDataReceiver : IDataReceiver
    {
        public DataResult<decimal> GetDecimal()
        {
            if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
            {
                return new DataResult<decimal>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }

            return GetErrorResult<decimal>();
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
