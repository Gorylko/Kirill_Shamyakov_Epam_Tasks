using FinanceAnalyzer.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class FinanceService : IFinanceService
    {
        IIncomeService _incomeService; //работает с контекстами данных
        IExpensesService _expensesService; //работает с контекстами данных
        //IDataDisplayer _dataDisplayer; //отображение инфы
        //IDataAdder _dataAdder; //добавление новых записей пользователем

        public FinanceService(IIncomeService incomeService)
        {
            this._incomeService = incomeService;
        }
    }
}
