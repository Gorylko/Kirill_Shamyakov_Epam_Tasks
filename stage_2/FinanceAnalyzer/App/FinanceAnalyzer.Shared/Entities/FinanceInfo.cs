namespace FinanceAnalyzer.Shared.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class FinanceInfo
    {
        public IReadOnlyCollection<decimal> IncomeHistoryCollection { get; set; }

        public IReadOnlyCollection<decimal> ExpensesHistoryCollection { get; set; }

        public decimal TotalIncome => IncomeHistoryCollection.Sum();

        public decimal TotalExpenses => ExpensesHistoryCollection.Sum();

        public decimal Profit => TotalIncome - TotalExpenses;
    }
}
