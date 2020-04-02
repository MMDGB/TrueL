using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Tryplication;
using Tryplication.Models;
using Xunit;

namespace TryplicationTest
{
    public class TryplicationControllerTest : TryplicationTest
    {
        public TryplicationControllerTest(TicketsEmployeeApiWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        private async Task TryplicationWrongHeader()
        {
            var response = await client.GetAsync("api/tickets");
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
            string message = await response.Content.ReadAsStringAsync();
            Assert.Equal("Invalid Pass", message);
          
        }
        [Fact]

        private async Task TryplicationGoodHeader()
        {
            client.DefaultRequestHeaders.Add("check-header-filter", "123456");
            var response = await client.GetAsync("api/tickets");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string message = await response.Content.ReadAsStringAsync();
            Assert.NotEqual("Invalid Pass", message);
        }
        [Fact]

        private async Task TryplicationTicketList()
        {
            client.DefaultRequestHeaders.Add("check-header-filter", "123456");
            var response = await client.GetAsync("api/tickets");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            List<Ticket> tickets = await JsonSerializer.DeserializeAsync<List<Ticket>>(responseStream);
            Assert.Equal(5, tickets.Count);
            Assert.NotEqual("TIK-000", tickets.First().TicketName);
            Assert.Equal("TIK-001", tickets.First().TicketName);


        }


    }
}
