using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Data.DataContext.Realizations;
using StructureMap;

namespace FinanceAnalyzer.Data.Dependency
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IExpensesContext<decimal>>().Use<ExpensesContext>();
            For<IIncomeContext<decimal>>().Use<IncomeContext>();
            For<ITaxContext<decimal>>().Use<TaxContext>();
        }
    }
}
