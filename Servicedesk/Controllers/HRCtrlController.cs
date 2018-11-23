using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicedesk.wwwroot.Js
{//not done!!!
    [Route("api/[controller]")]
    [ApiController]
    public class HRCtrlController : ControllerBase
    {
        [HttpGet]
        public object HR([FromBody]Employee userData)
        {
            return true;
        }
    }
}