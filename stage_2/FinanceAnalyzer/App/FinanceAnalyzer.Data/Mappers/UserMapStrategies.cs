namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using FinanceAnalyzer.Shared.Entities;

    internal class UserMapStrategies
    {
        internal static User MapUser(DataSet dataSet)
        {
            return dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0
                ? default
                : new User
                {
                    Id = dataSet.Tables[0].Rows[0].Field<int>("Id"),
                    Login = dataSet.Tables[0].Rows[0].Field<string>("Login"),
                    Password = dataSet.Tables[0].Rows[0].Field<string>("Password"),
                };
        }

        internal static IReadOnlyCollection<User> MapUserCollection(DataSet dataSet)
        {
            return dataSet == null
                ? default
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row =>
                    new User
                    {
                        Id = row.Field<int>("Id"),
                        Login = row.Field<string>("Login"),
                        Password = row.Field<string>("Password"),
                    })
                .ToArray();
        }
    }
}
