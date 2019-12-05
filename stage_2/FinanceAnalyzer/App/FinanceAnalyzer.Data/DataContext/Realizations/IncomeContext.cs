using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class IncomeContext : IIncomeContext<double>
    {
        public void Delete(double obj)
        {
            throw new NotImplementedException();
        }

        public DataResult<double> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(double obj)
        {
            throw new NotImplementedException();
        }
    }
}
