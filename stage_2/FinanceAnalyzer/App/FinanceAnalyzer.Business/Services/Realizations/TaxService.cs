using FinanceAnalyzer.Data.DataContext.Interfaces;
using System;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    internal class TaxService
    {
        private const decimal TaxPercentage = 13;
        private ITaxContext<decimal> _taxContext;
        public TaxService(ITaxContext<decimal> taxContext)
        {
            _taxContext = taxContext ?? throw new ArgumentNullException(nameof(taxContext));
        }

        public decimal TakeTax(decimal income)
        {
            var newIncome = income - (income * TaxPercentage / 100);

            _taxContext.Save(income - newIncome);

            return newIncome;
        }
    }
}
