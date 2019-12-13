using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IService<TValue, TResult>
    {
        Task<TResult> GetAll();

        Task Save(TValue obj);

        Task ClearAll();
    }
}
