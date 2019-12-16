using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace FinanceAnalyzer.IoC
{
    public class CustomContainer
    {
        private static IContainer _container;

        public static void Initialize()
        {
            _container = new Container(
                x => x.Scan
                       (
                           scan =>
                           {
                               AddBusinessDependency(scan);
                               AddDataDependency(scan);
                               scan.LookForRegistries();
                           }
                       )
          );
        }

        private static void AddBusinessDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<IIncomeService<decimal>>();
            scan.AssemblyContainingType<IExpensesService<decimal>>();
            scan.AssemblyContainingType<IFinanceService<decimal>>();
        }

        private static void AddDataDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<IExpensesContext<decimal>>();
            scan.AssemblyContainingType<IIncomeContext<decimal>>();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
