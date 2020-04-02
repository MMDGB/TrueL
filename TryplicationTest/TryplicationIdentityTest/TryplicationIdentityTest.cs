using System;
using System.Net.Http;
using TryplicationIdentity.IdentityServer;
using Xunit;

namespace TryplicationTest
{
    public class TryplicationIdentityTest : IClassFixture<TicketsEmployeeApiWebApplicationFactory<Startup>>
    {
        protected readonly TicketsEmployeeApiWebApplicationFactory<Startup> factory;
        protected readonly HttpClient client;

        public TryplicationIdentityTest(TicketsEmployeeApiWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Add("check-header-filter", "123456");
            this.factory = factory;
        }
    }
}