using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicedesk.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public const string OK = "OK";
        public const string ERROR = "ERROR";
        public static Dictionary<string, string> users = new Dictionary<string, string>();
        private static int countAdjustment = 0; 
        [HttpPost]
        public void Post()
        {
            string action = Request.Query["action"];
            string email = Request.Query["userName"];
            string password = Request.Query["password"];

            if (action == null || email == null || password == null) return;

            switch (action) {
                case "login":
                    Response.WriteAsync(Login(email, password) ? OK : ERROR);
                    break;
            }
        }

        private bool Login(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                    return false;
                conn.Open();
                return DatabaseEntity.ValidataUser(email, password,conn);
            }
            
        }
    }
}