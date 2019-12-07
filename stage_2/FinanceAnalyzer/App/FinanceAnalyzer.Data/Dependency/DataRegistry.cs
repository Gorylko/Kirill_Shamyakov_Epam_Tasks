using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Data.DataContext.Realizations;
using StructureMap;

namespace FinanceAnalyzer.Data.Dependency
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IExpensesContext<double>>().Use<ExpensesContext>();
            For<IIncomeContext<double>>().Use<IncomeContext>();
        }
    }
}
