using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Services
{
    internal static class SqlCommandExtensions
    {
        public static void AddParameters(this SqlCommand cmd, params SqlParameter[] parameters) 
        {
            cmd.Parameters.AddRange(parameters.Select(p => new SqlParameter(
                p.ParameterName, p.Value ?? DBNull.Value
            )).ToArray());
        }
    }
}
