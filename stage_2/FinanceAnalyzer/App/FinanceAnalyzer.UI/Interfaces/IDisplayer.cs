using FinanceAnalyzer.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI.Interfaces
{
    internal interface IDisplayer
    {
        void DisplayCollection<T>(IReadOnlyCollection<T> collection);

        void DisplayStartMenu();

        void DisplayNotification(string message);

        void DisplayMessage(string message);

        void DisplayIncome<T>(IReadOnlyCollection<T> collection);

        void DisplayExpenses<T>(IReadOnlyCollection<T> collection);

        void DisplayFullInformation(FinanceInfo financeInfo);
    }
}
