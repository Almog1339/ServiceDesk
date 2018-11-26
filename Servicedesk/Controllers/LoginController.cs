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
                switch (Employee.DepartmentID) {
                    case 1:
                    case 2:
                    case 6:

                        break;
                    case 3:
                    case 4:

                        break;
                    case 9:

                        break;
                    case 17:

                        break;
                    case 5:
                    case 7:
                    case 8:
                    case 12:
                    case 13:
                    case 15:

                        break;
                    case 10:
                    case 11:
                    case 16:
                    case 14:

                        break;
                    default:
                        break;
                }
            }
        }
    }
}