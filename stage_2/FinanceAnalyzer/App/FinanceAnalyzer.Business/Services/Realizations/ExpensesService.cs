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
            var returnCollection = this._expensesContext.GetAll();

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
            this._expensesContext.Save(obj);
        }
    }
}
