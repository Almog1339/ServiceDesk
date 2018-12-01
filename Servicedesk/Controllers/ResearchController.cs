using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Servicedesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchController : ControllerBase
    {
        [HttpGet]
        public HttpResponseMessage Research()
        {
            var path = "wwwroot/Research.html";
            var response = new HttpResponseMessage();
            response.IsSuccessStatusCode.ToString();
            return response;
        }

    }
}