namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Threading.Tasks;

    public interface IUserContext : IDataContext<User>
    {
        Task<User> GetByLoginAndPassword(string login, string password);
    }
}
