namespace Module.Helper.Results
{
    public class CountingResult<TParams>
    {
        public TParams Params { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}