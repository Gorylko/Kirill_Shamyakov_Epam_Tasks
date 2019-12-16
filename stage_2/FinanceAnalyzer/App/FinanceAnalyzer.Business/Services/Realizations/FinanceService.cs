using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService<decimal>
    {
        private readonly IExpensesService<decimal> _expensesService;
        private readonly IIncomeService<decimal> _incomeService;

        public FinanceService(
            IExpensesService<decimal> expensesService,
            IIncomeService<decimal> incomeService)
        {
            _expensesService = expensesService ?? throw new ArgumentNullException(nameof(expensesService));
            _incomeService = incomeService ?? throw new ArgumentNullException(nameof(incomeService));
        }

        public async Task<FinanceInfo> GetFullInformation()
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = await _incomeService.GetAll(),
                ExpensesHistoryCollection = await _expensesService.GetAll()
            };
        }

        public async Task<IReadOnlyCollection<decimal>> GetIncomeHistory()
        {
            return await _incomeService.GetAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetExpenseHistory()
        {
            return await _expensesService.GetAll();
        }

        public async Task AddNewIncome(decimal value)
        {
            await _incomeService.Save(value);
        }

        public async Task AddNewExpense(decimal value)
        {
            await _expensesService.Save(value);
        }

        public async Task ClearHistory()
        {
            await _expensesService.ClearAll();
            await _incomeService.ClearAll();
        }
    }
}
