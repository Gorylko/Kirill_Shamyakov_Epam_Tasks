using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IDisplayer
    {
        onsole.WriteLine(
                "1. Display income" + "\n" +
                "2. Display expenses" + "\n" +
                "3. Add New Income" + "\n" +
                "4. Add new expense" + "\n" +
                "5. Display full information" + "\n" + 
                "6. Exit"
        void DisplayCollection<T>(IReadOnlyCollection<T> collection);

        void DisplayStartMenu();

        void DisplayMessage(string message);

        void DisplayIncome<T>(IReadOnlyCollection<T> collection);

        void DisplayExpenses<T>(IReadOnlyCollection<T> collection);

        void DisplayFullInformation(FinanceInfo<double> financeInfo)
    }
}
