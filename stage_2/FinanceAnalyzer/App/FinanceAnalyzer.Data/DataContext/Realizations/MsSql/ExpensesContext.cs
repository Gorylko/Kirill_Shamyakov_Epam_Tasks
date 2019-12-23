namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.Constants;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using MapStrategy = FinanceAnalyzer.Data.Mappers.IncomeMapStrategies;

    public class ExpensesContext : IExpensesContext<decimal>
    {
        private IExecutor _executor;

        public ExpensesContext(IExecutor executor)
        {
            _executor = executor;
        }

        public async Task ClearAll()
        {
            await _executor.ExecuteNonQuery("sp_delete_all_expenses");
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            var dataSet = await _executor.ExecuteDataSet("sp_select_expenses_by_user_id", new Dictionary<string, object>
            {
                { "userId", SqlConstants.CurrentUserId },
            });

            var mapper = new Mapper<DataSet, Task<IReadOnlyCollection<decimal>>> { Map = MapStrategy.MapIncomes };
            return await mapper.Map(dataSet);
        }

        public async Task Save(decimal obj)
        {
            await _executor.ExecuteNonQuery("sp_insert_expense", new Dictionary<string, object>
            {
                { "amount", obj },
                { "userId", SqlConstants.CurrentUserId },
            });
        }
    }
}
