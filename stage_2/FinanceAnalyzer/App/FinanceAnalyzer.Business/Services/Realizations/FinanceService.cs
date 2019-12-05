using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Enums;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService
    {
        IIncomeService<double> _incomeService; 
        IExpensesService<double> _expensesService; 
        IDisplayer _displayer;
        IDataReceiver _dataReceiver;

        public FinanceService(
            IIncomeService<double> incomeService, 
            IExpensesService<double> expensesService, 
            IDisplayer displayer, 
            IDataReceiver dataReceiver)
        {
            this._incomeService = incomeService;
            this._expensesService = expensesService;
            this._displayer = displayer;
            this._dataReceiver = dataReceiver;
        }

        public void Launch()
        {
            do
            {
                this._displayer.DisplayStartMenu();
                var actionResult = this._dataReceiver.GetAction();

                if (actionResult.IsSuccessful)
                {
                    PerformAction(actionResult.Value);
                }

            } while (true);
        }

        private void PerformAction(ActionType action)
        {
            switch (action)
            {
                case ActionType.DisplayIncome:
                    this._displayer.
                    break;
                case ActionType.DisplayExpenses:
                    break;
                case ActionType.DisplayFullInformation:
                    break;
                case ActionType.AddNewIncome:
                    break;
                case ActionType.AddNewExpense:
                    break;
                case ActionType.Exit:
                    return;
            }
        }
    }
}
