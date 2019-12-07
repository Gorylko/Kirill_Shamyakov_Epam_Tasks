using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.IoC;
using FinanceAnalyzer.UI.Dependency;
using StructureMap;
using System;

namespace FinanceAnalyzer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var financeService = GetContainer().GetInstance<IFinanceService>();

            try
            {
                financeService.Launch();
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex);
            }
        }

        private static IContainer GetContainer()
        {
            CustomContainer.Initialize();

            var conteiner = CustomContainer.Container;
            conteiner.Configure(c => c.AddRegistry<UIRegistry>());

            return conteiner;
        }
    }
}
