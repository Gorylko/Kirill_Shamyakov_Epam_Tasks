namespace FinanceAnalyzer.UI.Data
{
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.UI.Interfaces;

    internal class Authorizer : IAuthorizer
    {
        public User GetCurrentUser()
        {
            throw new System.NotImplementedException();
        }

        public bool IsAuthorized()
        {
            throw new System.NotImplementedException();
        }
    }
}
