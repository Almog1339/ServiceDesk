using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Servicedesk
{
    public class DBHelper
    {
        public static string CONN_STRING;
        public static string ConnectionString{
            set
            {
                if (CONN_STRING == null)
                    CONN_STRING = "Data Source = DESKTOP - O8IU0PQ\\SQLEXPRESS; Initial Catalog = ServiceDesk; User ID = sa; Password = Q1w2q1w2";
            }
        }
    }
    public static class Extensions
    {
        public static string GetStringOrNull(this SqlDataReader dr, int i)
        {
            if (dr.IsDBNull(i))
                return null;
            return dr.GetString(i);
        }
    }
}
