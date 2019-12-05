using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IIncomeContext<T> : IDataContext<DataResult<IReadOnlyCollection<T>>, T> { } //can be expanded
}
