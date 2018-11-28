using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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
        public async Task<object> Login([FromBody]Employee userData)
        {
            if (string.IsNullOrEmpty(Employee.Password) || string.IsNullOrEmpty(Employee.LoginID)) {
                return false;
            }
            else {
                DatabaseEntity.ValidateUser(Employee.Password, Employee.LoginID);
                switch (Employee.DepartmentID) {
                    case 1:
                    case 2:
                    case 6:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                        
                    case 3:
                    case 4:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                      
                    case 9:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }

                    case 17:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                    case 5:
                    case 7:
                    case 8:
                    case 12:
                    case 13:
                    case 15:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                    case 10:
                    case 11:
                    case 16:
                    case 14:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                    default:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                return HrContent;
                            }
                        }
                }
            }
        }
    }
}