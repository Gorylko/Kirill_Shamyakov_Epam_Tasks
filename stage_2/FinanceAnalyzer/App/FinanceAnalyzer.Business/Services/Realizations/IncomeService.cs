using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class IncomeService : IIncomeService<double>
    {
        private IIncomeContext<double> _incomeContext;

        public IncomeService(IIncomeContext<double> incomeContext)
        {
            _incomeContext = incomeContext ?? throw new NullReferenceException(nameof(incomeContext));
        }

        public void ClearAll()
        {
            _incomeContext.ClearAll();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            var returnCollection = _incomeContext.GetAll();

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
            _incomeContext.Save(obj);
        }
    }
}
