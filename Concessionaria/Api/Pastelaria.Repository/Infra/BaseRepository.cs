
using Concessionaria.Repository.Infra.Extensions;
using Concessionaria.Repository.Infra.HandledExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Concessionaria.Repository.Infra
{
    public class BaseRepository
    {
        protected readonly IDatabaseConnection Connection;
        protected SqlCommand SqlCommand { get; set; }

        public BaseRepository(IDatabaseConnection connection)
        {
            Connection = connection;
        }

        public void OpenTransaction() => Connection.OpenTransaction();
        public void OpenTransaction(IsolationLevel isolationLevel) => Connection.OpenTransaction(isolationLevel);
        public void RollbackTransaction() => Connection.Rollback();
        public void CommitTransaction() => Connection.Commit();

        protected void OpenConnection()
        {
            try
            {
                if (SqlCommand.Connection.State == ConnectionState.Broken)
                {
                    SqlCommand.Connection.Close();
                    SqlCommand.Connection.Open();
                }

                if (SqlCommand.Connection.State == ConnectionState.Closed)
                    SqlCommand.Connection.Open();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 53)
                    throw new DbException("Falha ao efetuar conexão com o Banco de Dados");
                throw;
            }
        }

        public void CloseConnection() => Connection.SqlConnection.Close();

        protected void ExecuteProcedure(object procedureName)
        {
            SqlCommand = new SqlCommand(procedureName.ToString(), Connection.SqlConnection, Connection.SqlTransaction)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 99999
            };
        }

        protected void AddParameter(string parameterName, object parameterValue)
        {
            if (parameterValue is bool)
                SqlCommand.Parameters.Add(parameterName, SqlDbType.Bit).Value = parameterValue;
            else
                SqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
        }

        protected void AddParameterOutput(string parameterName, object parameterValue, DbType parameterType)
        {
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.Output,
                Value = parameterValue,
                DbType = parameterType
            });
        }

        protected void AddParameterOutput(string parameterName, SqlDbType parameterType, int parameterSize)
        {
            SqlCommand.Parameters.Add(parameterName, parameterType, parameterSize);
            SqlCommand.Parameters[parameterName].Direction = ParameterDirection.Output;
        }

        protected void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16)
        {
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = parameterType
            });
        }

        protected string GetParameterOutput(string parameter) => SqlCommand.Parameters[parameter].Value?.ToString();

        protected int ExecuteNonQuery()
        {
            try
            {
                OpenConnection();
                return SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        protected int ExecuteNonQueryWithReturn()
        {
            try
            {
                AddParameterReturn();
                OpenConnection();
                SqlCommand.ExecuteNonQuery();
                return int.Parse(SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        protected T ExecuteNonQueryWithReturn<T>()
        {
            try
            {
                AddParameterReturn();
                OpenConnection();
                SqlCommand.ExecuteNonQuery();
                var value = SqlCommand.Parameters["@RETURN_VALUE"].Value;
                if (value == DBNull.Value)
                    return default(T);

                return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        protected void Execute(object procedure, IEnumerable<Parameter> parameters)
        {
            ExecuteProcedure(procedure);
            foreach (var parameter in parameters)
                AddParameter(parameter.Name, parameter.Value);
            ExecuteNonQuery();
        }

        protected T ExecuteWithReturn<T>(object procedure, IEnumerable<Parameter> parameters)
        {
            ExecuteProcedure(procedure);
            foreach (var parameter in parameters)
                AddParameter(parameter.Name, parameter.Value);
            return ExecuteNonQueryWithReturn<T>();
        }

        protected IEnumerable<T> GetEnumerable<T>(object procedure, IEnumerable<Parameter> parameters) where T : class
        {
            ExecuteProcedure(procedure);
            foreach (var parameter in parameters)
                AddParameter(parameter.Name, parameter.Value);
            using (var r = ExecuteReader())
                return r.CastEnumerable<T>();
        }

        protected T GetEntity<T>(object procedure, IEnumerable<Parameter> parameters) where T : class
        {
            ExecuteProcedure(procedure);
            foreach (var parameter in parameters)
                AddParameter(parameter.Name, parameter.Value);
            using (var r = ExecuteReader())
                return r.Read() ? r.Cast<T>() : null;
        }

        protected IDataReader ExecuteReader()
        {
            try
            {
                OpenConnection();
                return SqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        protected IDataReader ExecuteReader(CommandBehavior cb)
        {
            try
            {
                return SqlCommand.ExecuteReader(cb);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        private static Exception HandleSqlException(SqlException ex)
        {
            if (ex.Number == 1205)
                return new DbException("Serviço indisponível, favor repetir a operação em alguns minutos ou contatar o DDP.");

            return ex;
        }
    }
}