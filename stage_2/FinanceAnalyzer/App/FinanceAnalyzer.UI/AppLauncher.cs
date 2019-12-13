using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.UI.Interfaces;
using Polly;
using Polly.Retry;
using System;

namespace FinanceAnalyzer.UI
{
    internal class AppLauncher : ILauncher
    {
        private bool _isAppOn;
        private IFinanceService _financeService;
        private IDataReceiver _dataReceiver;
        private IDisplayer _displayer;

        public AppLauncher(
            IFinanceService financeService,
            IDataReceiver dataReceiver,
            IDisplayer displayer)
        {
            _financeService = financeService;
            _dataReceiver = dataReceiver;
            _displayer = displayer;
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
                    _displayer.DisplayIncome(_financeService.GetIncomeHistory().Value);
                    break;
                case ActionType.DisplayExpenses:
                    _displayer.DisplayExpenses(_financeService.GetExpenseHistory().Value);
                    break;
                case ActionType.DisplayFullInformation:
                    _displayer.DisplayFullInformation(_financeService.GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    _financeService.ClearHistory();
                    break;
                case ActionType.Exit:
                    TurnOffApp();
                    break;
                default:
                    break;
            }
        }

        private void AddNewIncome()
        {
            //Policy
            //    .Handle<Exception>()
            //    .Retry(3, onRetry: (exception, retryCount) =>
            //    {
            //        _displayer.DisplayMessage("Enter new income");
            //        var doubleResult = _dataReceiver.GetDouble();

            //        if (!doubleResult.IsSuccessful)
            //        {
            //            throw new Exception();
            //        }

            //        _financeService.AddNewIncome(doubleResult.Value);
            //    });

            while (true)
            {
                _displayer.DisplayMessage("Enter new income");
                var doubleResult = _dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    _financeService.AddNewIncome(doubleResult.Value);
                    return;
                }

            }
        }

        private void AddNewExpense()
        {
            //Policy
            //   .Handle<Exception>()
            //   .Retry(3, onRetry: (exception, retryCount) =>
            //   {
            //       _displayer.DisplayMessage("Enter new expense");
            //       var doubleResult = _dataReceiver.GetDouble();

            //       if (!doubleResult.IsSuccessful)
            //       {
            //           throw new Exception();
            //       }

            //       _financeService.AddNewExpense(doubleResult.Value);
            //   });

            _displayer.DisplayMessage("Enter new expense");
            var doubleResult = _dataReceiver.GetDouble();

            if (doubleResult.IsSuccessful)
            {
                _financeService.AddNewExpense(doubleResult.Value);
                return;
            }

        }


        private void TurnOffApp()
        {
            _isAppOn = false;
        }

    }
}
