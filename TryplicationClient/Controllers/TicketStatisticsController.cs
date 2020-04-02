using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TryplicationClient.Models;
using TryplicationClient.Services;

namespace TryplicationClient.Controllers
{
    [Route("clientapi/[controller]")]
    [ApiController]
    public class TicketStatisticsController : ControllerBase
    {
        private readonly TicketsAPIService ticketApiService;

        public TicketStatisticsController(TicketsAPIService ticketApiService)
        {
            this.ticketApiService = ticketApiService;
        }

        public async Task<IEnumerable<TicketStatistics>> Get([FromQuery] OrderBy orderBy = OrderBy.Name)
        {
            return await ticketApiService.GetTicketStatistics(orderBy);
        }
    }
}