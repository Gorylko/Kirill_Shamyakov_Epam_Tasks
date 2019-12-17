namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Collections.Generic;

    public interface IExpensesContext<T> : IDataContext<IReadOnlyCollection<T>, T> { }
}
