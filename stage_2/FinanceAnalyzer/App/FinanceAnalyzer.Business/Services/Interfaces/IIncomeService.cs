using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IIncomeService<T> : IService<T, DataResult<IReadOnlyCollection<T>>>
    {
    }
}
