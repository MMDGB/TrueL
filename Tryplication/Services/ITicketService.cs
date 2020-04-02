using System.Collections.Generic;
using Tryplication.Models;

namespace Tryplication.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> Get();

        void Add(Ticket ticket);

        void Update(Ticket ticket);

        void Delete(long ticket);
    }
}