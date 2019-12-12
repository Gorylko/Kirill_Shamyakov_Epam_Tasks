using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;

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

        public FinanceInfo GetFullInformation()
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = _incomeService.GetAll().Value,
                ExpensesHistoryCollection = _expensesService.GetAll().Value
            };
        }

        public DataResult<IReadOnlyCollection<double>> GetIncomeHistory()
        {
            return _incomeService.GetAll();
        }

        public DataResult<IReadOnlyCollection<double>> GetExpenseHistory()
        {
            return _expensesService.GetAll();
        }

        public void AddNewIncome(double value)
        {
            _incomeService.Save(value);
        }

        public void AddNewExpense(double value)
        {
            _expensesService.Save(value);
        }

        public void ClearHistory()
        {
            _expensesService.ClearAll();
            _incomeService.ClearAll();
        }
    }
}
