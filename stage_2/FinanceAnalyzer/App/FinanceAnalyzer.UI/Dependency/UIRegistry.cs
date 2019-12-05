using StructureMap;
using System;
using System.Collections.Generic;
using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.UI.Displayers;
using FinanceAnalyzer.UI.DataReceivers;

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
