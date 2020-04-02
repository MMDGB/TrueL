using Microsoft.Extensions.Configuration;

namespace TryplicationClient.Services
{
    public class ClientCredentials : IClientCredentials
    {
        public ClientCredentials(IConfiguration configuration)
        {
            var clientInfo = configuration.GetSection("ClientCredentials");
            ClientId = clientInfo.GetValue<string>("ClientId");
            ClientSecret = clientInfo.GetValue<string>("ClientSecret");
            Scope =  clientInfo.GetValue<string>("Scope");
        }

        public string ClientId { get; }
        public string ClientSecret { get; }
        public string Scope { get; }
    }
}