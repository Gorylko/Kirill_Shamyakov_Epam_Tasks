using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Realizations
{
    public class LoginService : ILoginService
    {
        public Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetCookie()
        {
            using (FileStream fileStream = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                return await JsonSerializer.DeserializeAsync<User>(fileStream);
            }
        }

        public Task SaveCookie()
        {
            throw new NotImplementedException();
        }
    }
}
