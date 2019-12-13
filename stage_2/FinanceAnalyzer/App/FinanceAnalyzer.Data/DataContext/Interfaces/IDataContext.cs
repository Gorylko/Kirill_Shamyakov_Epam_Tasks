using System.Threading.Tasks;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IDataContext<TResult, TValue>
    {
        Task<TResult> GetAll();

        Task Save(TValue obj);

        Task ClearAll();
    }
}
