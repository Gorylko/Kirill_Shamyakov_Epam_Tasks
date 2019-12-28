using FinanceAnalyzer.Shared.Entities;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface ILoginService
    {
        Task SaveCookie();

        Task<User> GetCookie();

        Task<User> Login(User user);
    }
}
