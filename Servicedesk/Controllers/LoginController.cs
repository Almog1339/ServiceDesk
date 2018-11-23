//using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicedesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public const string OK = "OK";
        public const string ERROR = "ERROR";
        public static Dictionary<string, string> users = new Dictionary<string, string>();

        [HttpPost]
        public object Login([FromBody]Employee userData)
        {
            if (string.IsNullOrEmpty(Employee.Password) || string.IsNullOrEmpty(Employee.LoginID)) {
                return false;
            }
            else {
                return DatabaseEntity.ValidateUser(Employee.LoginID, Employee.Password,Employee.DepartmentID);
            }
        }
    }
}