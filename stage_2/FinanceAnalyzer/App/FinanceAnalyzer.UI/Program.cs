using FinanceAnalyzer.Business;
using System;
using StructureMap;
using StructureMap.Graph;
using FinanceAnalyzer.IoC;
using FinanceAnalyzer.UI.Dependency;
using FinanceAnalyzer.Business.Services.Interfaces;

namespace FinanceAnalyzer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomContainer.Initialize();
            var conteiner = CustomContainer.Container;
            conteiner.Configure(c => c.AddRegistry<UIRegistry>());
            var financeService = conteiner.GetInstance<IFinanceService>();

            try
            {
                financeService.Launch();
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
