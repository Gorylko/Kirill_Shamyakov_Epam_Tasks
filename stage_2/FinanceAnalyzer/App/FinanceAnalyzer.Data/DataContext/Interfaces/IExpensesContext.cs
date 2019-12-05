using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IExpensesContext<T> : IDataContext<DataResult<IReadOnlyCollection<T>>, T> { }//can be expanded
}
