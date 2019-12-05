using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.UI.DataReceivers;
using FinanceAnalyzer.UI.Displayers;
using StructureMap;

namespace FinanceAnalyzer.UI.Dependency
{
    public class UIRegistry : Registry
    {
        public UIRegistry()
        {
            For<IDisplayer>().Use<ConsoleDisplayer>();
            For<IDataReceiver>().Use<ConsoleDataReceiver>();
        }
    }
}
