namespace FinanceAnalyzer.Shared.Results
{
    public class DataResult<TValue>
    {
        public TValue Value { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
