using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Tryplication.Models;

namespace Tryplication.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> tickets;
        private readonly ITicketGenerator ticketsGenerator;
        private readonly ILogger _logger;


        public TicketService(ILogger<TicketService> logger, ITicketGenerator ticketGenerator)
        {
            tickets = new List<Ticket>();
            this.ticketsGenerator = ticketGenerator;
            _logger = logger;
            Initialize();
        }

        private void Initialize()
        {
            tickets.AddRange(ticketsGenerator.GenerateTickets());
            _logger.LogInformation("The ticket list was initialized");
        }

        public void Add(Ticket ticket)
        {
            lock (tickets)
            {
                tickets.Add(ticket);
            }
            _logger.LogInformation("A new ticket was added!");    
        }

        public void Delete(long ticketId)
        {
            lock (tickets)
            {
                tickets.RemoveAll(s => s.Id == ticketId);
            }
            _logger.LogInformation("The ticket with id" + ticketId.ToString() + " was deleted");
        }

        public IEnumerable<Ticket> Get()
        {
            _logger.LogInformation("The list with all tickets was requested");
            return tickets;
        }

        public void Update(Ticket ticket)
        {
            lock (tickets)
            {
                Ticket ticketToUpdate = tickets.Single(s => s.Id == ticket.Id);
                ticketToUpdate.TicketName = ticket.TicketName;
                ticketToUpdate.TicketComplexity = ticket.TicketComplexity;
            }
        }
    }
}