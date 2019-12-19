namespace FinanceAnalyzer.Data.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class IncomeMapStrategies
    {
        internal static async Task<IReadOnlyCollection<decimal>> MapIncomes(DataSet dataSet)
        {
            return dataSet.Tables[0]
                .AsEnumerable()
                .Select(row => row.Field<decimal>("Amount"))
                .ToList();
        }
    }
}
