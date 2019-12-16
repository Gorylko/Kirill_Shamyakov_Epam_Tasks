namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITaxContext<T> : IDataContext<IReadOnlyCollection<T>, T>
    {
    }
}
