using System.Collections.Generic;
using System.Data.SqlClient;

namespace HawkSoftTest
{
    public interface IDataAccess
    {
        List<T> ExecuteStoredProcedure<T>(string procedure, SqlParameterCollection parameters) where T : new();
    }
}