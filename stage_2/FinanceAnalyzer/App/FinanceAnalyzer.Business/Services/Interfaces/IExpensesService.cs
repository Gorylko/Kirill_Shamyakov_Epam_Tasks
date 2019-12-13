using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IExpensesService<T> : IService<T, IReadOnlyCollection<T>> { }
}
