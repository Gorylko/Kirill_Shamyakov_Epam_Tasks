using System.Collections.Generic;
using System.Linq;

namespace FinanceAnalyzer.Shared.Entities
{
    public class FinanceInfo
    {
        public IReadOnlyCollection<double> IncomeHistoryCollection { get; set; }

        public IReadOnlyCollection<double> ExpensesHistoryCollection { get; set; }

        public double TotalIncome => IncomeHistoryCollection.Sum();

        public double TotalExpenses => ExpensesHistoryCollection.Sum();

        public double Profit => TotalIncome - TotalExpenses;
    }
}
