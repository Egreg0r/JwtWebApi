using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> Gettickets()
        {
            return await _context.tickets.ToListAsync();
        }

        // GET: api/Tickets/token
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Ticket>>> PostTicket(Ticket ticket)
        {
            if (ticket.message.Contains("history"))
            {
                var col = _context.tickets.Count() - 10;
                return await _context.tickets.Skip(col).ToListAsync();
            }
            else
            {
                _context.tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

    }
}
