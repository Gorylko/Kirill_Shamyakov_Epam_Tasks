﻿using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class ExpensesContext : IExpensesContext<double>
    {
        public void Delete(double obj)
        {
            throw new NotImplementedException();
        }

        public DataResult<double> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save(double obj)
        {
            throw new NotImplementedException();
        }
    }
}
