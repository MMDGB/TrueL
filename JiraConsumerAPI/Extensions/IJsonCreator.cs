using System.Net;
using System.Threading.Tasks;

namespace JiraConsumerAPI.Extensions
{
    public interface IJsonCreator
    {
        Task<string> GetJiraWorklogAsync(string jiraIssueId);

        string GetKnownTicket(string jiraIssueId);

        Task<string> GetJiraIssueAsync(string jiraIssueId);

        NetworkCredential GetCred();
    }
}