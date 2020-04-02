using System;
using System.Net.Http;
using TryplicationClient;
using Xunit;


namespace TryplicationTest
{
    public class TryplicationClientTest : IClassFixture<TicketsEmployeeApiWebApplicationFactory<Startup>>
    {
        protected readonly TicketsEmployeeApiWebApplicationFactory<TryplicationClient.Startup> factory;
        protected readonly HttpClient client;

        public TryplicationClientTest(TicketsEmployeeApiWebApplicationFactory<TryplicationClient.Startup> factory)
        {
            client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Add("check-header-filter", "123456");
            
            this.factory = factory;
        }
    }
}
