using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HawkSoftTest
{
    public class SqlServerDataAccess : IDataAccess
    {
        string ConnectionString { get; }

        public SqlServerDataAccess(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("HawkSoftTestDB");
        }

        public List<T> ExecuteStoredProcedure<T>(string procedure, params SqlParameter[] sqlParameters) where T : new()
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(procedure, conn);

            cmd.Parameters.AddRange(sqlParameters);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Connection.Open();

            using var reader = cmd.ExecuteReader();
            var data = MapData<T>(reader);
            return data;
        }

        private List<T> MapData<T>(SqlDataReader reader) where T : new()
        {
            var items = new List<T>();
            while (reader.Read())
            {
                var item = new T();

                //TODO: Check performance against expected loads and see if a non-reflection solution is needed.
                foreach(PropertyInfo prop in item.GetType().GetProperties())
                {
                    if (!Equals(reader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(item, reader[prop.Name], null);
                    }
                }

                items.Add(item);
            }
            return items;
        }

        public int ExecuteNonQuery(string procedure, params SqlParameter[] sqlParameters)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(procedure, conn);

            cmd.Parameters.AddRange(sqlParameters);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Connection.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
