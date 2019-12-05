using FinanceAnalyzer.Business.Services.Realizations;
using FinanceAnalyzer.Business.Services.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Dependency
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IIncomeService>().Use<IncomeService>();
            For<IFinanceService>().Use<FinanceService>();
            For<IExpensesService>().Use<ExpensesService>();
        }
    }
}
