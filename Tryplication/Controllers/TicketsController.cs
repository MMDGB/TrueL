using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Tryplication.Fiters;
using Tryplication.Models;
using Tryplication.Services;

namespace Tryplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly ILogger _logger;

        public TicketsController(ILoggerFactory factory, ITicketService ticketService)
        {
            this.ticketService = ticketService;
            _logger = factory.CreateLogger("TicketController");
        }

        [HttpGet]
        [CustomFilter]
        public IEnumerable<Ticket> Get()
        {
            return ticketService.Get().ToList();
        }

        [HttpGet("{id}")]
        [CustomFilter]
        public ActionResult<Ticket> Get(long id)
        {
            string s = "hi";
            int h = int.Parse(s);

            try
            {
                _logger.LogInformation("In search for ticket with id: {id}", id);
                return ticketService.Get().Single(s => s.Id == id);
            }
            catch (InvalidOperationException)
            {
                _logger.LogError("The ticket with id: {id} was not found", id);
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ticket ticket)
        {
            _logger.LogInformation("Proceed Post Request");
            if (ticketService.Get().Any(s => s.Id == ticket.Id))
            {
                _logger.LogInformation("The id exists --> Proceed Update");
                ticketService.Update(ticket);
                return Ok(ticket);
            }

            ticketService.Add(ticket);
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Ticket ticket)
        {
            if (ticket.Id != id)
            {
                return BadRequest();
            }
            if (!ticketService.Get().Any(s => s.Id == ticket.Id))
            {
                return NotFound();
            }

            ticketService.Update(ticket);
            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            if (!ticketService.Get().Any(s => s.Id == id))
            {
                return NotFound();
            }

            ticketService.Delete(id);
            return Ok();
        }
    }
}