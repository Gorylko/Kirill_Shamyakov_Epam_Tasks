using FinanceAnalyzer.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IFinanceService<T>
    {
        Task<FinanceInfo> GetFullInformation();

        Task AddNewExpense(T value);

        Task AddNewIncome(T value);

        Task ClearHistory();

        Task<IReadOnlyCollection<T>> GetIncomeHistory();

        Task<IReadOnlyCollection<T>> GetExpenseHistory();
    }
}
