using System;
using System.Collections.Generic;
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
        [HttpGet]
        public void Get()
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
            return ValidataUser(email, password);
        }
        private bool ValidataUser(string email,string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                return false;
            if (users.ContainsKey(email)) {
                return users[email] == password;
            }return true;
        }
    }
}