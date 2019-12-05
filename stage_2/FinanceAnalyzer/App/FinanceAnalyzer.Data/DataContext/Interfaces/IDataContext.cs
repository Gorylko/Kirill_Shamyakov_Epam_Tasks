using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IDataContext<T>
    {
        T GetByUserId(int userId);

        void Save(T obj);

        void Delete(T obj);
    }
}
