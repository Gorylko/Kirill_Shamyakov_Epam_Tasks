namespace FinanceAnalyzer.UI.Data
{
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.UI.Interfaces;

    internal class CookieManager : ICookieManager
    {
        private User _user;

        public async Task<User> GetUserFromCookie()
        {
            try
            {
                using (FileStream fileStream = new FileStream("user.json", FileMode.OpenOrCreate))
                {
                    return await JsonSerializer.DeserializeAsync<User>(fileStream);
                }
            }
            catch (JsonException)
            {
                return default;
            }
        }

        public Task SaveUserCookie(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
