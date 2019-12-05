﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IDataContext<TResult, TValue>
    {
        TResult GetAll();

        void Save(TValue obj);

        void Delete(TValue obj);
    }
}
