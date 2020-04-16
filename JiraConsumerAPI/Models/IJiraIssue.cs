namespace JiraConsumerAPI.Models
{
    public interface IJiraIssue
    {
        string CompleteName { get; set; }
        decimal TimeSpent { get; set; }
    }
}
