using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryplication.Models
{
    public class Ticket
    {
        [JsonPropertyName("id")]

        public long? Id { get; set; }
        [JsonPropertyName("ticketName")]

        public string TicketName { get; set; }
        [JsonPropertyName("ticketComplexity")]

        public string TicketComplexity { get; set; }
        [JsonPropertyName("assignedEmplyee")]

        public Employee AssignedEmplyee { get; set; }
    }
}