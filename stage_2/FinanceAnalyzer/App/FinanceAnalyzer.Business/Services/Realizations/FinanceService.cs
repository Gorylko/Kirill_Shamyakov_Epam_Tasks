using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Enums;
using System;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService
    {
        private IIncomeService<double> _incomeService;
        private IExpensesService<double> _expensesService;
        private IDataReceiver _dataReceiver;
        private IDisplayer _displayer;
        private bool _isAppOn;

        public FinanceService(
            IExpensesService<double> expensesService,
            IIncomeService<double> incomeService,
            IDataReceiver dataReceiver,
            IDisplayer displayer)
        {
            this._expensesService = expensesService ?? throw new NullReferenceException(nameof(expensesService));
            this._incomeService = incomeService ?? throw new NullReferenceException(nameof(incomeService));
            this._dataReceiver = dataReceiver ?? throw new NullReferenceException(nameof(dataReceiver));
            this._displayer = displayer ?? throw new NullReferenceException(nameof(displayer));

            this._isAppOn = true;
        }

        public void Launch()
        {
            while (this._isAppOn)
            {
                this._displayer.DisplayStartMenu();

                var actionResult = this._dataReceiver.GetAction();

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
                    this._displayer.DisplayIncome(this._incomeService.GetAll().Value);
                    break;
                case ActionType.DisplayExpenses:
                    this._displayer.DisplayExpenses(this._expensesService.GetAll().Value);
                    break;
                case ActionType.DisplayFullInformation:
                    this._displayer.DisplayFullInformation(GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    this.AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    this.AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    this._expensesService.ClearAll();
                    this._incomeService.ClearAll();
                    break;
                case ActionType.Exit:
                    this._isAppOn = false;
                    break;
                default:
                    break;
            }
        }

        private FinanceInfo GetFullInformation()
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = this._incomeService.GetAll().Value,
                ExpensesHistoryCollection = this._expensesService.GetAll().Value
            };
        }

        private void AddNewIncome()
        {
            while (true)
            {
                this._displayer.DisplayMessage("Enter new income");
                var doubleResult = this._dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    this._incomeService.Save(doubleResult.Value);
                    return;
                }
            }
        }

        private void AddNewExpense()
        {
            while (true)
            {
                this._displayer.DisplayMessage("Enter new expense");
                var doubleResult = this._dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    this._expensesService.Save(doubleResult.Value);
                    return;
                }
            }
        }
    }
}
