namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using FinanceAnalyzer.Shared.Entities;

    class UserContext : IUserContext
    {
        private readonly IExecutor _executor;

        public UserContext(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

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
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_user_by_id",
                new Dictionary<string, object>
                {
                    { "id", id },
                });

            var mapper = new Mapper<DataSet, User> { Map = UserMapStrategies.MapUser };
            return mapper.Map(dataSet);
        }

        public async Task Save(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
