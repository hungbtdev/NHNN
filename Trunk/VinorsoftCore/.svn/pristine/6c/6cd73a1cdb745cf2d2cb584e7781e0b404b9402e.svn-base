using System.Data.Common;
using System.Data.SqlClient;

namespace KTApps.Core.Factory
{
    public class SqlDbProviderFactory : IVDbProviderFactory
    {
        public DbParameter CreateParameter(string parameterName, object value)
        {
            return new SqlParameter()
            {
                ParameterName = parameterName,
                Value = value
            };
        }
        
    }
}
