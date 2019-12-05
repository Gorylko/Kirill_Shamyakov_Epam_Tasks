using FinanceAnalyzer.Business.Services.Interfaces;
using StructureMap;
using StructureMap.Graph;
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
                               scan.LookForRegistries();
                           }
                       )
          );
        }

        private static void AddBusinessDependency(IAssemblyScanner scan)
        {
            scan.AssemblyContainingType<IIncomeService>();
            scan.AssemblyContainingType<IFinanceService>();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}
