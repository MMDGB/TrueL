using System.Net;
using System.Threading.Tasks;
using Xunit;
using TryplicationIdentity.IdentityServer;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TryplicationTest
{
    public class TryplicationIdentityControllerTest : TryplicationIdentityTest
    {
        public TryplicationIdentityControllerTest(TicketsEmployeeApiWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        private async Task TestAddClient()
        {
            var response = await client.GetAsync("api/ClientsManagement?id=Student2&secret=secret2&scope=admin");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]

        private async Task TestConfiguration()
        {
            var response = await client.GetAsync(".well-known/openid-configuration");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]

        private async Task TestGetToken()
        {
            StringContent content = new StringContent("");

            var response = await client.PostAsync("connect/token", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", "StudentAPIAdmin" },
                { "client_secret", "admin-password" },
                { "scope", "studentapi.admin" }
            };

            var myContent = JsonConvert.SerializeObject(dict);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var result = await client.PostAsync("connect/token", byteContent);

        }
    }
}