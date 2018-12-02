using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO;
using System;

namespace Servicedesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task Login([FromBody]Employee userData)
        {
            if (string.IsNullOrEmpty(userData.Password) || string.IsNullOrEmpty(userData.LoginID)) {

            }
            else {
                int DepartmentID;

                DepartmentID = DatabaseEntity.ValidateUser(userData.LoginID, userData.Password);

                switch (DepartmentID) {
                    case 1:
                    case 2:
                    case 6:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                break;
                            }
                        }
                    case 3:
                    case 4:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                break;
                            }
                        }

                    case 9:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                break;
                            }
                        }

                    case 17:
                        using (HttpClient HrClient = new HttpClient()) {
                            using (HttpResponseMessage httpResponse = await HrClient.GetAsync("api/HrCtrlController")) {
                                HttpContent content = httpResponse.Content;
                                string HrContent = await content.ReadAsStringAsync();
                                break;
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
                                break;
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
                                break;
                            }
                        }
                    default:
                        break;
                }
            }
        }

    }
}
