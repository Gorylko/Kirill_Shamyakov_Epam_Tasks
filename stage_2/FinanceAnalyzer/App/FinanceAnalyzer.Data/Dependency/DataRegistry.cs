namespace FinanceAnalyzer.Data.Dependency
{
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Realizations;
    using StructureMap;

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
