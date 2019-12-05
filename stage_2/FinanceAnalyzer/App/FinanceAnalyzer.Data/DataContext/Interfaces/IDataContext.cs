namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IDataContext<TResult, TValue>
    {
        TResult GetAll();

        void Save(TValue obj);

        void ClearAll();
    }
}
