﻿using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    internal class ExpensesService : IExpensesService<double>
    {
        private IExpensesContext<double> _expensesContext;

        public ExpensesService(IExpensesContext<double> expensesContext)
        {
            _expensesContext = expensesContext ?? throw new ArgumentNullException(nameof(expensesContext));
        }

        public async Task ClearAll()
        {
            await _expensesContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<double>> GetAll()
        {
            return await _expensesContext.GetAll();
        }

        public async Task Save(double obj)
        {
            await _expensesContext.Save(obj); 
        }
    }
}
