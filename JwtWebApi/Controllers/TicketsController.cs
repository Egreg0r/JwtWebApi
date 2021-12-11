using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using JwtWebApi.Model;
using JwtWebApi.Data;


namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly BaseContext _context;

        public TicketsController(BaseContext context)
        {
            _context = context;

        }

        // POST: api/Tickets
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Ticket>>> PostTicket(Ticket ticket)
        {
            if (ticket.Message == ("history 10"))
            {

                var t = await _context.tickets.Where(l => l.LoginModelUserName == ticket.LoginModelUserName).ToListAsync();
                return t.TakeLast(10).ToList();
            }
            else
            {
                _context.tickets.Add(new Ticket
                {
                    LoginModelUserName = ticket.LoginModelUserName,
                    Message = ticket.Message,
                    CreateDate = DateTime.Now
                }) ;
                await _context.SaveChangesAsync();
            }

            return Ok ("Ticket is add succseful ");
        }

    }
}
