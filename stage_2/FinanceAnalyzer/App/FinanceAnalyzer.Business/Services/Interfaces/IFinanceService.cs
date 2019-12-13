using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IFinanceService
    {
        Task<FinanceInfo> GetFullInformation();

        Task AddNewExpense(double value);

        Task AddNewIncome(double value);

        Task ClearHistory();

        Task<IReadOnlyCollection<double>> GetIncomeHistory();

        Task<IReadOnlyCollection<double>> GetExpenseHistory();
    }
}
