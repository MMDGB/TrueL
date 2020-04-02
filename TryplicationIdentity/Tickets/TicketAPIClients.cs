using IdentityServer4.Models;
using System.Collections.Generic;

namespace TryplicationIdentity.Student
{
    public class TicketAPIClients : ITicketAPIClients
    {
        private readonly List<Client> clients;

        public TicketAPIClients()
        {
            this.clients = new List<Client>
            {
                new Client()
                {
                    ClientId = "StudentAPIAdmin",

                    ClientSecrets = {
                        new Secret("admin-password".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes =
                    {
                        "studentapi.admin",
                        "studentapi.readwrite",
                        "studentapi.readonly"
                    }
                }
            };
        }

        public Client CreateAndStoreClient(string id, string secret, string scope)
        {
            switch (scope)
            {
                case "readwrite":
                    scope = "studentapi.readwrite";
                    break;

                case "read":
                    scope = "studentapi.readonly";
                    break;

                case "admin":
                    scope = "studentapi.admin";
                    break;

                default:
                    scope = "";
                    break;
            }
            Client newClient = new Client()
            {
                ClientId = id,
                ClientSecrets = { new Secret(secret.Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { scope }
            };

            clients.Add(newClient);
            return newClient;
        }

        public List<Client> GetAll()
        {
            return clients;
        }


        public void Add(Client client)
        {
            lock (clients)
            {
                clients.Add(client);
            };
        }
    }
}
