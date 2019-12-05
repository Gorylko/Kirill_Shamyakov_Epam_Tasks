using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.UI.DataReceivers
{
    public class ConsoleDataReceiver : IDataReceiver
    {
        public DataResult<double> GetDouble()
        {
            throw new NotImplementedException();
        }

        public DataResult<int> GetInt()
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return new UserInputResult<int>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }

            return GetErrorResult<int>("Invalid value of user input");
        }

        private DataResult<T> GetErrorResult<T>(string errorMessage)
        {

        }
    }
}
