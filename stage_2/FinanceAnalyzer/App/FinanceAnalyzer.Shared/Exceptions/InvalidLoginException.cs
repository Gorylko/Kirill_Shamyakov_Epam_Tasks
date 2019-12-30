namespace FinanceAnalyzer.Shared.Exceptions
{
    using System;

    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message)
            : base(message)
        {
        }

        public InvalidLoginException()
        {
        }
    }
}
