namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    public class LoginService : ILoginService
    {
        private readonly IUserContext _userContext;

        public LoginService(IUserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<User> Login(string login, string password)
        {
            password = GetEncryptedString(password);
            return await _userContext.GetByLoginAndPassword(login, password);
        }

        private string GetEncryptedString(string input)
        {
            //magic
            return input;
        }
    }
}
