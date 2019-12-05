using FinanceAnalyzer.Business;
using System;
using StructureMap;
using StructureMap.Graph;
using FinanceAnalyzer.IoC;
using FinanceAnalyzer.Business.Services.Interfaces;

namespace FinanceAnalyzer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomContainer.Initialize();
            var conteiner = CustomContainer.Container;
            var financeService = conteiner.GetInstance<IFinanceService>();

            financeService.Launch();

            Console.ReadKey();
        }
    }
}
