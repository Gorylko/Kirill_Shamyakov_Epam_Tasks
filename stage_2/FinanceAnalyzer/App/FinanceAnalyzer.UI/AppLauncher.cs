using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.UI.Interfaces;
using Polly;
using System;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI
{
    internal class AppLauncher : ILauncher
    {
        private bool _isAppOn;
        private const int MaxAttemptsNumber = 3;
        private readonly IFinanceService _financeService;
        private readonly IDataReceiver _dataReceiver;
        private readonly IDisplayer _displayer;

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

        public async Task Launch()
        {
            while (_isAppOn)
            {
                _displayer.DisplayStartMenu();

                var actionResult = _dataReceiver.GetAction();

                if (actionResult.IsSuccessful)
                {
                    await PerformAction(actionResult.Value);
                }
            }
        }

        private async Task PerformAction(ActionType action)
        {
            switch (action)
            {
                case ActionType.DisplayIncome:
                    _displayer.DisplayIncome(await _financeService.GetIncomeHistory());
                    break;
                case ActionType.DisplayExpenses:
                    _displayer.DisplayExpenses(await _financeService.GetExpenseHistory());
                    break;
                case ActionType.DisplayFullInformation:
                    _displayer.DisplayFullInformation(await _financeService.GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    await AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    await AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    await _financeService.ClearHistory();
                    break;
                case ActionType.Exit:
                    TurnOffApp();
                    break;
                default:
                    break;
            }
        }

        private async Task AddNewIncome()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new income");
                var doubleResult = _dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    await _financeService.AddNewIncome(doubleResult.Value);
                    return;
                }
                else if(currentAttempt == MaxAttemptsNumber)
                {
                    _displayer.DisplayNotification(doubleResult.ErrorMessage);
                }
            }
        }

        private async Task AddNewExpense()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new expense");
                var doubleResult = _dataReceiver.GetDouble();

                if (doubleResult.IsSuccessful)
                {
                    await _financeService.AddNewExpense(doubleResult.Value);
                    return;
                }
                else if (currentAttempt == MaxAttemptsNumber)
                {
                    _displayer.DisplayNotification(doubleResult.ErrorMessage);
                }
            }
        }


        private void TurnOffApp()
        {
            _isAppOn = false;
        }

    }
}
