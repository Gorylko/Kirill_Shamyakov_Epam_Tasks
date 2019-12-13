using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    internal class IncomeService : IIncomeService<double>
    {
        private readonly IIncomeContext<double> _incomeContext;

        public IncomeService(IIncomeContext<double> incomeContext)
        {
            _incomeContext = incomeContext ?? throw new ArgumentNullException(nameof(incomeContext));
        }

        public async Task ClearAll()
        {
            await _incomeContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<double>> GetAll()
        {
            return await _incomeContext.GetAll();
        }

        public async Task Save(double obj)
        {
            await _incomeContext.Save(obj);
        }
    }
}
