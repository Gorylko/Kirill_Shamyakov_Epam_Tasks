namespace Task1.DataInitializers
{
    public class DataInitializerResult<TParams>
    {
        public TParams Parameters { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
