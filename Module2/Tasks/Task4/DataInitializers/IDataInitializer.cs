namespace Task4.DataInitializers
{
    public interface IDataInitializer<TParams>
    {
        DataInitializerResult<TParams> InitializeData();
    }
}
