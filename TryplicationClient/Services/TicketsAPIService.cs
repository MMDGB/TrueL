using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Tryplication.Models;
using TryplicationClient.Models;

namespace TryplicationClient.Services
{
    public class TicketsAPIService
    {
        private readonly HttpClient client;

        public TicketsAPIService(HttpClient client)
        {
            this.client = client;
            client.BaseAddress = new Uri("https://localhost:5002/");
            client.DefaultRequestHeaders.Add("check-header-filter", "123456");
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/tickets");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string message = string.Format(
                    "Error while using TicketApi (status code: {0}, reason: {1})",
                    response.StatusCode,
                    response.ReasonPhrase);

                throw new HttpRequestException(message);
            }

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Ticket>>(responseStream);
        }

        public async Task<IEnumerable<TicketStatistics>> GetTicketStatistics(OrderBy orderBy = OrderBy.Name)
        {
            var getTicketTask = GetTickets();

            var result = new List<TicketStatistics>();
            var tickets = await getTicketTask;

            foreach (var ticket in tickets)
            {
                result.Add(new TicketStatistics()
                {
                    Name = ticket.TicketName + " " + ticket.TicketComplexity,
                    AssignedDevelopers = ticket.AssignedEmplyee.Name,
                });
            }

            return result;
        }
    }
}