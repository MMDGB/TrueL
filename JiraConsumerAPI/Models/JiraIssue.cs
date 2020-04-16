namespace JiraConsumerAPI.Models
{
    public class JiraIssue : IJiraIssue
    {
        public string CompleteName { get; set; }
        public decimal TimeSpent { get; set; }
    }
}
