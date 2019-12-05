using FinanceAnalyzer.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IDisplayer
    {
        void DisplayCollection<T>(IReadOnlyCollection<T> collection);

        void DisplayStartMenu();

        void DisplayMessage(string message);

        void DisplayIncome<T>(IReadOnlyCollection<T> collection);

        void DisplayExpenses<T>(IReadOnlyCollection<T> collection);

        void DisplayFullInformation(FinanceInfo financeInfo);
    }
}
