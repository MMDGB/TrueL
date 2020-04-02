using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TryplicationIdentity.Student;

namespace TryplicationIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsManagementController : ControllerBase
    {
        public readonly ITicketAPIClients _clients;

        public ClientsManagementController(ITicketAPIClients clients)
        {
            _clients = clients;
        }

        public List<Client> Get()
        {
            return _clients.GetAll();
        }

        [HttpPost]
        public Client CreateClient([FromQuery]string id, [FromQuery]string secret, [FromQuery]string scope)
        {
            return _clients.CreateAndStoreClient(id, secret, scope);
        }

        [HttpDelete]
        public ActionResult DeleteClient([FromQuery]string id)
        {
            var client = _clients.GetAll().Where(c => c.ClientId == id).FirstOrDefault();
            if (client != null)
            {
                _clients.GetAll().Remove(client);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}