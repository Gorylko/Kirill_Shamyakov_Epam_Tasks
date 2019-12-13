using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.IoC;
using FinanceAnalyzer.UI.Dependency;
using FinanceAnalyzer.UI.Interfaces;
using StructureMap;
using System;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var launcher = GetContainer().GetInstance<ILauncher>();

            try
            {
                await launcher.Launch();
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
