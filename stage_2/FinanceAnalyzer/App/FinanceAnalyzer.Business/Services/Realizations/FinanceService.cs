using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Enums;
using System;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService
    {
        private IExpensesService<double> _expensesService;
        private IIncomeService<double> _incomeService;
        private IDataReceiver _dataReceiver;
        private IDisplayer _displayer;
        private bool _isAppOn;

        public FinanceService(
            IExpensesService<double> expensesService,
            IIncomeService<double> incomeService,
            IDataReceiver dataReceiver,
            IDisplayer displayer)
        {
            _expensesService = expensesService ?? throw new NullReferenceException(nameof(expensesService));
            _incomeService = incomeService ?? throw new NullReferenceException(nameof(incomeService));
            _dataReceiver = dataReceiver ?? throw new NullReferenceException(nameof(dataReceiver));
            _displayer = displayer ?? throw new NullReferenceException(nameof(displayer));

            _isAppOn = true;
        }

        public void Launch()
        {
            while (_isAppOn)
            {
                _displayer.DisplayStartMenu();

                var actionResult = _dataReceiver.GetAction();

                if (actionResult.IsSuccessful)
                {
                    PerformAction(actionResult.Value);
                }
            }
        }

        private void PerformAction(ActionType action)
        {
            switch (action)
            {
                case ActionType.DisplayIncome:
                    _displayer.DisplayIncome(_incomeService.GetAll().Value);
                    break;
                case ActionType.DisplayExpenses:
                    _displayer.DisplayExpenses(_expensesService.GetAll().Value);
                    break;
                case ActionType.DisplayFullInformation:
                    _displayer.DisplayFullInformation(GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    _expensesService.ClearAll();
                    _incomeService.ClearAll();
                    break;
                case ActionType.Exit:
                    NewMethod();
                    break;
                default:
                    break;
            }
        }

        private void NewMethod()
        {
            _isAppOn = false;
        }

        private FinanceInfo GetFullInformation()
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = _incomeService.GetAll().Value,
                ExpensesHistoryCollection = _expensesService.GetAll().Value
            };
        }

        private void AddNewIncome()
        {
            while (true)
            {
                _displayer.DisplayMessage("Enter new income");
                var doubleResult = _dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    _incomeService.Save(doubleResult.Value);
                    return;
                }
            }
        }

        private void AddNewExpense()
        {
            while (true)
            {
                _displayer.DisplayMessage("Enter new expense");
                var doubleResult = _dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    _expensesService.Save(doubleResult.Value);
                    return;
                }
            }
        }
    }
}
