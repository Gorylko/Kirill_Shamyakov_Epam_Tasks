using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    internal class ExpensesService : IExpensesService<double>
    {
        private IExpensesContext<double> _expensesContext;

        public ExpensesService(IExpensesContext<double> expensesContext)
        {
            _expensesContext = expensesContext ?? throw new ArgumentNullException(nameof(expensesContext));
        }

        public void ClearAll()
        {
            _expensesContext.ClearAll();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            var returnCollection = _expensesContext.GetAll();

            return returnCollection == null
                ? new DataResult<IReadOnlyCollection<double>>
                {
                    IsSuccessful = false,
                    ErrorMessage = "Value of collection is null"
                }
                : new DataResult<IReadOnlyCollection<double>>
                {
                    Value = returnCollection,
                    IsSuccessful = true
                };
        }

        public void Save(double obj)
        {
            _expensesContext.Save(obj); 
        }
    }
}
