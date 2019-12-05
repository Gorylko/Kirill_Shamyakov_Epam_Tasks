using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IDataReceiver
    {
        DataResult<int> GetInt();

        DataResult<double> GetDouble();
    }
}
