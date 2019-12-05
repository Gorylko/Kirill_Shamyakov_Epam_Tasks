using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.UI.Displayers
{
    public class ConsoleDisplayer : IDisplayer
    {
        public void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "1. Display income" + "\n" +
                "2. Display expenses" + "\n" +
                "3. Add New Income" + "\n" +
                "4. Add new expense" + "\n" +
                "5. Display full information" + "\n" + 
                "6. Exit"
                );
        }

        

        public void DisplayCollection<T>(IReadOnlyCollection<T> collection)
        {
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
            this.DisplayMessage("Income : ");

            if (collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                this.DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayExpenses<T>(IReadOnlyCollection<T> collection)
        {
            this.DisplayMessage("Expenses : ");

            if(collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                this.DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayFullInformation(FinanceInfo financeInfo)
        {
            Console.Clear();
            Console.WriteLine(
                         $"Total income : {financeInfo.TotalIncome}" + "\n" +
                         $"Total Expenses : {financeInfo.TotalExpenses}" + "\n" +
                         $"Profit : {financeInfo.Profit}" + "\n"
                         );

            Console.ReadKey();
        }
    }
   
}
