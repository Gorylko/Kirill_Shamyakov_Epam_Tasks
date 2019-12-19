namespace FinanceAnalyzer.Data.DbContext.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public interface IExecutor
    {
        DataSet ExecuteDataSet(string procedureName, IDictionary<string, object> values = null);


        int ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null);
    }
}
