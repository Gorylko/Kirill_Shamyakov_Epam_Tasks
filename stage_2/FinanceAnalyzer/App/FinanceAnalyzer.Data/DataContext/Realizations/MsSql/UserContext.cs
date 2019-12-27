namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    class UserContext : IUserContext
    {
        private readonly IExecutor _executor;

        public async Task ClearAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            
        }

        public async Task Save(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
