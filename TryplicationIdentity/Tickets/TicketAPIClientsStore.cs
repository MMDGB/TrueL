using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Linq;
using System.Threading.Tasks;

namespace TryplicationIdentity.Student
{
    public class TicketAPIClientsStore : IClientStore
    {
        public readonly ITicketAPIClients clients;

        public TicketAPIClientsStore(ITicketAPIClients clients)
        {
            this.clients = clients;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(clients.GetAll().SingleOrDefault(c => c.ClientId == clientId));
        }
    }
}