using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IExpensesContext<T> : IDataContext<DataResult<T>, T>
    {
    }
}
