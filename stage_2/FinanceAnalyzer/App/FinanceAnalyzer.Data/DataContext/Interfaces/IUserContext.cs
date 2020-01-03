namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.Models;
    using FinanceAnalyzer.Shared.Entities;

    public interface IUserContext : IDataContext<UserDBModel>
    {
        Task<User> GetByLoginAndPassword(string login, byte[] password);

        Task<byte[]> GetUserSaltByLogin(string login);
    }
}
