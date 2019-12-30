namespace FinanceAnalyzer.UI.Interfaces
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Threading.Tasks;

    internal interface IAuthorizer
    {
        Task<User> GetUserFromCookie();
    }
}
