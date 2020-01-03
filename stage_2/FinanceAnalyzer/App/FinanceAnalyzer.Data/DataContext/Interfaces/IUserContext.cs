namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;

    public interface IUserContext : IDataContext<User>
    {
        Task<User> GetByLoginAndPassword(byte[] login, byte[] password);

        Task<byte> GetUserSaltByLogin(string login);
    }
}
