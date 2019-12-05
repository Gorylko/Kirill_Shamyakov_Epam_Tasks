using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IIncomeService<T> : IService<T, DataResult<IReadOnlyCollection<T>>> { }
}
