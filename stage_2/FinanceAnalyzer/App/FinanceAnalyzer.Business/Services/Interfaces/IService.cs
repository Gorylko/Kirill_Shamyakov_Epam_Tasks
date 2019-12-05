namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IService<TValue, TResult>
    {
        TResult GetAll();

        void Save(TValue obj);

        void ClearAll();
    }
}
