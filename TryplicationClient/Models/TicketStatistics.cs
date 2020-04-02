namespace TryplicationClient.Models
{
    public class TicketStatistics
    {
        public string Name { get; set; }
        public string AssignedDevelopers { get; set; }
    }

    public enum OrderBy
    {
        Name,
        AssignedDevelopers,
    }
}