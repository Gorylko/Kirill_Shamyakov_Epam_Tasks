using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Text;

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
            throw new NotImplementedException();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(double obj)
        {
            throw new NotImplementedException();
        }
    }
}
