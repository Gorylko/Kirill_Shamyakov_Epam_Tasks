using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.IoC;
using FinanceAnalyzer.UI.Dependency;
using FinanceAnalyzer.UI.Interfaces;
using StructureMap;
using System;

namespace FinanceAnalyzer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var launcher = GetContainer().GetInstance<ILauncher>();

            try
            {
                launcher.Launch();
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
