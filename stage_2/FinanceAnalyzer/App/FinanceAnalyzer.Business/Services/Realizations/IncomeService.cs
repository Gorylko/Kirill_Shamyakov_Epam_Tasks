using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class IncomeService : IIncomeService<double>
    {
        private IIncomeContext<double> _incomeContext;

        public IncomeService(IIncomeContext<double> incomeContext)
        {
            this._incomeContext = incomeContext ?? throw new NullReferenceException(nameof(incomeContext));
        }

        public void ClearAll()
        {
            this._incomeContext.ClearAll();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            return this._incomeContext.GetAll();
        }

        public void Save(double obj)
        {
            this._incomeContext.Save(obj);
        }
    }
}
