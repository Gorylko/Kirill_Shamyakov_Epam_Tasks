using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IService<TResult, TValue>
    {
        TResult GetByUserId(int userId);

        void Save(TValue obj);

        void Delete(TValue obj);
    }
}
