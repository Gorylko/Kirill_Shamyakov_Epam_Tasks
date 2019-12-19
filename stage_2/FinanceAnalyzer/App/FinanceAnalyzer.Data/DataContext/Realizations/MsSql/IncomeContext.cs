namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using MapStrategy = FinanceAnalyzer.Data.Mappers.IncomeMapStrategies;

    public class IncomeContext : IIncomeContext<decimal>
    {
        private IExecutor _executor;

        public IncomeContext(IExecutor executor)
        {
            _executor = executor;
        }

        public Task ClearAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            var dataSet = _executor.ExecuteDataSet("sp_select_incomes_by_user_id", new Dictionary<string, object>
            {
                { "userId", 1 },
            });

            var mapper = new Mapper<DataSet, Task<IReadOnlyCollection<decimal>>> { Map = MapStrategy.MapIncomes };
            return await mapper.Map(dataSet);
        }

        public async Task Save(decimal obj)
        {
            _executor.ExecuteNonQuery("sp_insert_income"); //не работает пока, уже 10 ночи((( иду домой спатьки
        }
    }
}
