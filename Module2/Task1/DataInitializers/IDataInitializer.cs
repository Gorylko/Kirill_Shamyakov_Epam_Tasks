namespace Task1.DataInitializers
{
    public interface IDataInitializer<TParams>
    {
        DataInitializerResult<TParams> InitializeData();
    }
}
