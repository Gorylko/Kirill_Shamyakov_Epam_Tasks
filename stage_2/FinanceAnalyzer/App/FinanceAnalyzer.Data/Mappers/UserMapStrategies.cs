namespace FinanceAnalyzer.Data.Mappers
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Data;

    internal class UserMapStrategies
    {
        internal static User MapUser(DataSet dataSet)
        {
            return dataSet == null
                ? default
                : new User
                {
                    Id = dataSet.Tables[0].Rows[0].Field<int>("Id"),
                    Login = dataSet.Tables[0].Rows[0].Field<string>("Login"),
                    Password = dataSet.Tables[0].Rows[0].Field<string>("Password"),
                };
        }
    }
}
