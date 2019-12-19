﻿namespace FinanceAnalyzer.Data.DbContext.Realization
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Constants;
    using FinanceAnalyzer.Data.Helpers;

    internal class ProcedureExecutor : IExecutor
    {
        private SqlConnectionHelper _connectionHelper = new SqlConnectionHelper();

        public DataSet ExecuteDataSet(string procedureName, IDictionary<string, object> values = null)
        {
            DataSet dataSet = null;
            using (var connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                var procedure = CreateProcedure(procedureName, values);
                procedure.Connection = connection;
                connection.Open();
                var adapter = new SqlDataAdapter(procedure);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
            }

            return dataSet;
        }

        public int ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null)
        {
            using (var connecton = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                var procedure = CreateProcedure(procedureName, values);
                procedure.Connection = connecton;
                connecton.Open();
                return procedure.ExecuteNonQuery();
            }
        }

        private SqlCommand CreateProcedure(string procedureName, IDictionary<string, object> values = null)
        {
            var command = new SqlCommand
            {
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure,
            };
            if (values != null)
            {
                foreach (var param in values)
                {
                    var parameter = CreateParameter(param);
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private SqlParameter CreateParameter(KeyValuePair<string, object> param)
        {
            return new SqlParameter
            {
                ParameterName = "@" + param.Key,
                Value = param.Value,
            };
        }
    }
}
