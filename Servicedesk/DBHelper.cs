using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Servicedesk.wwwroot
{
    public class DBHelper
    {
        public static string CONN_STRING;
        public static string ConnectionString
        {
            set
            {
                if (CONN_STRING == null)
                    CONN_STRING = value;
            }
        }
    }
    public static class Extension
    {
        public static string GetStingOrNull(this SqlDataReader dr,int i)
        {
            if (dr.isDBNull(i))
                return null;
            return dr.GetString(i);
        }
    }
}
