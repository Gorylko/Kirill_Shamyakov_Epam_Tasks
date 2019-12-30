namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    public class LoginService : ILoginService
    {
        public Task<User> Login(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
