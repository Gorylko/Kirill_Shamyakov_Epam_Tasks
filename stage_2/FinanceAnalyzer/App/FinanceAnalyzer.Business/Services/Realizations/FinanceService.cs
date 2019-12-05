using FinanceAnalyzer.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            this._displayer.DisplayStartMenu();
        }
    }
}
