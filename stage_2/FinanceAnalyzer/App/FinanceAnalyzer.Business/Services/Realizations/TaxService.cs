using FinanceAnalyzer.Data.DataContext.Interfaces;
using System;
using FinanceAnalyzer.Business.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    internal class TaxService : ITaxService
    {
        private const decimal TaxPercentage = 13;
        private ITaxContext<decimal> _taxContext;

        public TaxService(ITaxContext<decimal> taxContext)
        {
            _taxContext = taxContext ?? throw new ArgumentNullException(nameof(taxContext));
        }

        public async Task ClearAll()
        {
            await _taxContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            return await _taxContext.GetAll();
        }

        public async Task Save(decimal obj)
        {
            await _taxContext.Save(obj);
        }

        public async Task<decimal> TakeTax(decimal income)
        {
            var newIncome = income - (income * TaxPercentage / 100);

            await _taxContext.Save(income - newIncome);

            return newIncome;
        }
    }
}
