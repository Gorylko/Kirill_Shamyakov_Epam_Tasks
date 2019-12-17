﻿namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Collections.Generic;

    public interface ITaxContext<T> : IDataContext<IReadOnlyCollection<T>, T>
    {
    }
}
