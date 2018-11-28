using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicedesk
{
    public abstract class DatabaseEntity
    {
        protected abstract Column[] Columns { get; }
        protected abstract string TableName { get; }
        protected abstract Column PrimaryKey { get; }

        public delegate T ItemCreator<T>(SqlDataReader dr);
        private string GetColumnsCommaSeparated(bool withPrimaryKey, bool withAtSign = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Column col in Columns) {
                if (!withPrimaryKey && col.ColumnType == ColumnType.PRIMARY_KEY)
                    continue;
                if (withAtSign)
                    sb.Append("@");
                sb.Append(col.Name + ",");
            }
            if (Columns.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
       
        public string SelectSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(GetColumnsCommaSeparated(true));
            sb.Append(" FROM " + TableName);
            return sb.ToString();
        }
        public List<T> GetList<T>(ItemCreator<T> itemCreator)
        {
            List<T> item = new List<T>();
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                conn.Open();
                using (SqlCommand command = new SqlCommand(SelectSql(), conn)) {
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        while (dr.Read()) {
                            T databaseEntity = itemCreator(dr);
                            item.Add(databaseEntity);
                        }
                    }
                }
            }
            return item;
        }
        public static object ValidateUser(string LoginID, string Password)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT LoginID, PasswordSalt FROM HumanResources.Employee " +
                    "LEFT JOIN PERSON.Password ON HumanResources.Employee.BusinessEntityID = Person.Password.BusinessEntityID " +
                    "WHERE HumanResources.Employee.LoginID = @LoginID AND Person.Password.PasswordSalt = @Password");
               
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                {
                    cmd.Parameters.AddWithValue("@LoginID", LoginID);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("SELECT HumanResources.Department.DepartmentID FROM HumanResources.Employee LEFT JOIN HumanResources.EmployeeDepartmentHistory ON HumanResources.Employee.BusinessEntityID = HumanResources.EmployeeDepartmentHistory.BusinessEntityID LEFT JOIN HumanResources.Department ON HumanResources.EmployeeDepartmentHistory.DepartmentID = HumanResources.Department.DepartmentID WHERE HumanResources.EmployeeDepartmentHistory.EndDate IS NULL AND LoginID=@LoginID", Employee.DepartmentID);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    {
                        if (dr.Read()) {
                            return Employee.DepartmentID;
                        }
                    }
                    conn.Close();
                }
            }
            return false;
        }
        
        public bool Delete(object PrimaryKeyToBeDeleted)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteSQL(), conn)) {
                    cmd.Parameters.AddWithValue("@" + PrimaryKey.Name, PrimaryKeyToBeDeleted);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private string DeleteSQL()
        {
            StringBuilder sb = new StringBuilder();
            if (PrimaryKey == null) {
                throw new Exception("Cannot delete without Ticket Number.");
            }
            sb.Append("DELETE FROM " + TableName + "WHERE " + PrimaryKey + "=@" + PrimaryKey);
            return sb.ToString();
        }

        public string InsertSQL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO" + TableName + " (");
            sb.Append(GetColumnsCommaSeparated(false) + ") VALUSE (");
            sb.Append(GetColumnsCommaSeparated(false, true) + ")");
            return sb.ToString();
        }

        public string Update(SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + TableName);
            sb.Append("SET " + GetColumnsCommaSeparated(false) + ") VALUES (");
            sb.Append(GetColumnsCommaSeparated(false, true) + ")");
            return sb.ToString();
        }
    }
}