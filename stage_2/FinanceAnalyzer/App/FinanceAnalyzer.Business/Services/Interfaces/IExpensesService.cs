using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IExpensesService<T> : IService<T, DataResult<IReadOnlyCollection<T>>>
    {
    }
}
