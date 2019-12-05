namespace Task4.DataInitializers
{
    public class UserInputResult<TParam>
    {
        public TParam Param { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
