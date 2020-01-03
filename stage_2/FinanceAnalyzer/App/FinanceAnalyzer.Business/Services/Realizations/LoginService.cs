﻿namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Cryptographers;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    public class LoginService : ILoginService
    {
        private readonly Cryptographer _cryptographer;
        private readonly IUserContext _userContext;

        public LoginService(IUserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _cryptographer = new Cryptographer();
        }

        public async Task<User> Login(string login, string password)
        {
            var salt = await _userContext.GetUserSaltByLogin(login);

            return await _userContext.GetByLoginAndPassword(
                login,
                _cryptographer.Encrypt(password, salt));
        }

        public Task<User> Register(string login, string password)
        {
            var encryptedPassword = _cryptographer.Encrypt(login, out byte[] salt);

            _userContext.Save(new User
            {
                Login = login,
                Password = encryptedPassword,

            });
        }
    }
}
