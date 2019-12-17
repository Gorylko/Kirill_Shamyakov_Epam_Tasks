using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IExpensesService : IService<decimal, IReadOnlyCollection<decimal>> { }
}
