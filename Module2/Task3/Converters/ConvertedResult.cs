namespace Task3.Converters
{
    public class ConvertedResult<TResult>
    {
        public TResult Value { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
