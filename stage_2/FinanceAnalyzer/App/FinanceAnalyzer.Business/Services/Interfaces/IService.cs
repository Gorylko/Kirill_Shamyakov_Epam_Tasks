using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IService<TValue, TResult>
    {
        TResult GetAll();

        void Save(TValue obj);

        void ClearAll();
    }
}
