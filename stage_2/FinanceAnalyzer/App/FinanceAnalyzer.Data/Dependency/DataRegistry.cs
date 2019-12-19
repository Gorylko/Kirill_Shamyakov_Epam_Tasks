namespace FinanceAnalyzer.Data.Dependency
{
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Realizations;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Realization;
    using StructureMap;

    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IExpensesContext<decimal>>().Use<ExpensesContext>();
            For<IIncomeContext<decimal>>().Use<DataContext.Realizations.MsSql.IncomeContext>();
            For<ITaxContext<decimal>>().Use<TaxContext>();
            For<IExecutor>().Use<ProcedureExecutor>();
        }
    }
}
