using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI.Displayers
{
    public class ConsoleDisplayer : IDisplayer
    {
        public void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine(
@"1. Display income
2. Display expenses
3. Add New Income
4. Add new expense
5. Display full information
6. Clear history
7. Exit");
        }



        public void DisplayCollection<T>(IReadOnlyCollection<T> collection)
        {
            if (collection == null)
            {
                return;
            }

            foreach (var el in collection)
            {
                Console.WriteLine(el);
            }
        }

        public void DisplayMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        public void DisplayIncome<T>(IReadOnlyCollection<T> collection)
        {
            DisplayMessage("Income : ");

            if (collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayExpenses<T>(IReadOnlyCollection<T> collection)
        {
            DisplayMessage("Expenses : ");

            if (collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayFullInformation(FinanceInfo financeInfo)
        {
            Console.Clear();
            Console.WriteLine(
 $@" Total income : {financeInfo.TotalIncome}
 Total Expenses : {financeInfo.TotalExpenses}
 Profit : {financeInfo.Profit}");

            Console.ReadKey();
        }
    }

}
