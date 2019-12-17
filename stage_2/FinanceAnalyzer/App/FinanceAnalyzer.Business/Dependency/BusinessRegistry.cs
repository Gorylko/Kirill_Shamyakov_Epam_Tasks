using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Business.Services.Realizations;
using StructureMap;

namespace FinanceAnalyzer.Business.Dependency
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IIncomeService>().Use<IncomeService>();
            For<IFinanceService<decimal>>().Use<FinanceService>();
            For<IExpensesService>().Use<ExpensesService>();
            For<ITaxService>().Use<TaxService>();
        }
    }
}
