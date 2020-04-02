using IdentityServer4.Models;
using System.Collections.Generic;

namespace TryplicationIdentity.Student
{
    public interface ITicketAPIClients
    {
        void Add(Client client);

        List<Client> GetAll();

        Client CreateAndStoreClient(string id, string secret, string scope);
    }
}