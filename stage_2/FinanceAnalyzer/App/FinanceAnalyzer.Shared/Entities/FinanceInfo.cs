using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinanceAnalyzer.Shared.Entities
{
    public class FinanceInfo
    {
        public IReadOnlyCollection<double> IncomeHistoryCollection { get; set; }

        public IReadOnlyCollection<double> ExpensesHistoryCollection { get; set; }

        public double TotalIncome => this.IncomeHistoryCollection.Sum();

        public double TotalExpenses => this.ExpensesHistoryCollection.Sum();

        public double Profit => this.TotalIncome - this.TotalExpenses;
    }
}
