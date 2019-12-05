using FinanceAnalyzer.Business.Services.Interfaces;
using StructureMap;
using StructureMap.Graph;
using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Data.DataContext.Realizations;
using FinanceAnalyzer
using System;
using System.Collections.Generic;
using System.Text;

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
            scan.AssemblyContainingType<IIncomeService<double>>();
            scan.AssemblyContainingType<IExpensesService<double>>();
            scan.AssemblyContainingType<IFinanceService>();
        }

        private static void AddDataDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<IExpensesContext<double>>();
            scan.AssemblyContainingType<IIncomeContext<double>>();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
