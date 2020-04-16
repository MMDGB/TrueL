using Newtonsoft.Json;
using OfficeDevPnP.Core.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Threading.Tasks;

namespace JiraConsumerAPI.Extensions
{
    public class JsonCreator : IJsonCreator
    {
        private readonly NetworkCredential credentials;
        
        public JsonCreator()
        {
            credentials = CredentialManager.GetCredential("git:https://git.fortech.ro");
        }

        public NetworkCredential GetCred()
        {
            return credentials;
        }
        public async Task<string> GetJiraWorklogAsync(string jiraIssueId)
        {
            RestClient getClient = new RestClient(Constants.JiraBase + jiraIssueId + "/worklog")
            {
                Authenticator = new HttpBasicAuthenticator(credentials.UserName, credentials.Password)
            };
            return await GetJsonAsync(getClient);
        }

        public string GetKnownTicket(string jiraIssueId)
        {
            RestClient getClient = new RestClient(Constants.JiraBase + jiraIssueId + "/worklog")
            {
                Authenticator = new HttpBasicAuthenticator(credentials.UserName, credentials.Password)
            };
            return GetJson(getClient);
        }


        public async Task<string> GetJiraIssueAsync(string jiraIssueId)
        {
            RestClient getClient = new RestClient(Constants.JiraBase + jiraIssueId)
            {
                Authenticator = new HttpBasicAuthenticator(credentials.UserName, credentials.Password)
            };
            return await GetJsonAsync(getClient);
        }

        private async Task<string> GetJsonAsync(RestClient getClient)
        {
            var getRequest = new RestRequest(Method.GET);
            IRestResponse result = await Task.Run(() => getClient.Execute(getRequest));
            return result.Content;
        }

        private string GetJson(RestClient getClient)
        {
            var getRequest = new RestRequest(Method.GET);
            IRestResponse result =  getClient.Execute(getRequest);
            return result.Content;
        }


    }
}
