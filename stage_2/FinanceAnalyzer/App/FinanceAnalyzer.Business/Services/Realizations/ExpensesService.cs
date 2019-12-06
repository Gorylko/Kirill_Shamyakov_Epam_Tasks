using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class ExpensesService : IExpensesService<double>
    {
        private IExpensesContext<double> _expensesContext;

        public ExpensesService(IExpensesContext<double> expensesContext)
        {
            this._expensesContext = expensesContext ?? throw new NullReferenceException(nameof(expensesContext));
        }

        public void ClearAll()
        {
            this._expensesContext.ClearAll();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            return new DataResult<IReadOnlyCollection<double>>
            {
                Value = this._expensesContext.GetAll(),
                IsSuccessful = true
            };
        }

        public void Save(double obj)
        {
            this._expensesContext.Save(obj);
        }
    }
}
