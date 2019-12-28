namespace FinanceAnalyzer.UI.Data
{
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.UI.Interfaces;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;

    internal class Authorizer : IAuthorizer
    {
        private User _user;

        public async Task<User> GetCurrentUser()// не смотреть на этот ужас!
        {
            var cookie = await GetCookie();

            if(cookie == null)
            {
            }

            return _user;
        }

        public async Task<bool> TryAuthorize(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetCookie()
        {
            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    User user = new Person() { Name = "Tom", Age = 35 };
            //    await JsonSerializer.SerializeAsync<User>(fs, tom);
            //}

            return null;
        }
    }
}
