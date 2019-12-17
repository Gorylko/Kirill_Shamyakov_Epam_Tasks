using FinanceAnalyzer.UI.DataReceivers;
using FinanceAnalyzer.UI.Displayers;
using FinanceAnalyzer.UI.Interfaces;
using StructureMap;

namespace FinanceAnalyzer.UI.Dependency
{
    public class UIRegistry : Registry
    {
        public UIRegistry()
        {
            For<ILauncher>().Use<AppLauncher>();
            For<IDisplayer>().Use<ConsoleDisplayer>();
            For<IDataReceiver>().Use<ConsoleDataReceiver>();
        }
    }
}
