using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IFinanceService
    {
        FinanceInfo GetFullInformation();

        void AddNewExpense(double value);

        void AddNewIncome(double value);

        void ClearHistory();

        DataResult<IReadOnlyCollection<double>> GetIncomeHistory();

        DataResult<IReadOnlyCollection<double>> GetExpenseHistory();
    }
}
