using System.Collections.Generic;
using System.Data.SqlClient;

namespace HawkSoftTest
{
    public interface IDataAccess
    {
        List<T> ExecuteStoredProcedure<T>(string procedure, params SqlParameter[] sqlParameters) where T : new();
    }
}