namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Threading.Tasks;

    public interface IDataContext<TResult, TValue>
    {
        Task<TResult> GetAll();

        Task Save(TValue obj);

        Task ClearAll();
    }
}
