using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Business.Services.Realizations;
using StructureMap;

namespace FinanceAnalyzer.Business.Dependency
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IIncomeService<double>>().Use<IncomeService>();
            For<IFinanceService>().Use<FinanceService>();
            For<IExpensesService<double>>().Use<ExpensesService>();
        }
    }
}
