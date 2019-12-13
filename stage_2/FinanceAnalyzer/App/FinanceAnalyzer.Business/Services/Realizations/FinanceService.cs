using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService
    {
        private IExpensesService<double> _expensesService;
        private IIncomeService<double> _incomeService;

        public FinanceService(
            IExpensesService<double> expensesService,
            IIncomeService<double> incomeService)
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

        public async Task<IReadOnlyCollection<double>> GetIncomeHistory()
        {
            return await _incomeService.GetAll();
        }

        public async Task<IReadOnlyCollection<double>> GetExpenseHistory()
        {
            return await _expensesService.GetAll();
        }

        public async Task AddNewIncome(double value)
        {
            await _incomeService.Save(value);
        }

        public async Task AddNewExpense(double value)
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
