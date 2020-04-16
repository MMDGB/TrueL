namespace JiraConsumerAPI.Models
{
    public interface IPolarionTicket
    {
        Filter Filter { get; set; }
        IComment Name { get; set; }
        decimal TimeSpent { get; set; }
        string CompleteName { get; set; }
    }
}
