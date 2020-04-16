namespace JiraConsumerAPI.Models
{
    public interface IComment
    {
        string Base { get; set; }

        string PolarionExtension { get; set; }
    }
}
