using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicedesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
       [HttpGet]
       public List<Tickets> GetTickets()
        {
            Tickets ticket = new Tickets();
            return ticket.GetTickets();
        }

    }
}