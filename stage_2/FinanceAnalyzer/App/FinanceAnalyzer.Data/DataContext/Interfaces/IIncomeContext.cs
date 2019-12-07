using System.Collections.Generic;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IIncomeContext<T> : IDataContext<IReadOnlyCollection<T>, T> { } //can be expanded
}
