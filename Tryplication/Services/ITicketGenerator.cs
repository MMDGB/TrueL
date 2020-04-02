using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public interface ITicketGenerator
    {
        IEnumerable<Ticket> GenerateTickets();
    }
}