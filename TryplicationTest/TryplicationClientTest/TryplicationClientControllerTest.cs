using System.Net;
using System.Threading.Tasks;
using TryplicationClient;
using Xunit;

namespace TryplicationTest
{
    public class TryplicationClientControllerTest : TryplicationClientTest
    {
        public TryplicationClientControllerTest(TicketsEmployeeApiWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        private async Task TestWrongHeader()
        {
            var response = await client.GetAsync("clientapi/ticketstatistics");
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        private async Task TestGoodHeader()
        {
           // var response = await client.GetAsync(".well-known/openid-configuration");
          //  Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        private async Task TestTicketList()
        {
            //var response = await client.GetAsync("connect/token");
            // var responseStream = await response.Content.ReadAsStreamAsync();
        }
    }
}