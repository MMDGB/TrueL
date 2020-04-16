using JiraConsumerAPI.Extensions;
using JiraConsumerAPI.Models;
using JiraConsumerAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace JiraConsumerAPI.Contexts
{
    public class TicketsService : ITicketsService
    {
        private readonly IDataCreator dataCreator;
        private readonly IReport report;
        private readonly IJsonCreator jsonCreator;
        private IJiraConfiguration _jiraConfiguration;

        public TicketsService(IJiraConfiguration jiraConfiguration)
        {
            report = new Report();
            dataCreator = new DataCreator();
            jsonCreator = new JsonCreator();
            _jiraConfiguration = jiraConfiguration;
        }

        public async Task<string> GetSerializedResultAsync(Filter filter, DateTime start, DateTime end, string jiraIssue)
        {
            JObject jsObject;
            if (_jiraConfiguration.KnownTasks.ContainsKey(jiraIssue))
            {
                jsObject = _jiraConfiguration.KnownTasks[jiraIssue];
            }
            else
            {
                jsObject = JObject.Parse(await jsonCreator.GetJiraWorklogAsync(jiraIssue));
                _jiraConfiguration.KnownTasks.Add(jiraIssue, jsObject);
            }

            return filter.ShowUsers
                ? JsonConvert.SerializeObject(report.CreateDetailedPolarionTicketList(jsObject, start, end, filter))
                : JsonConvert.SerializeObject(report.CreatePolarionTicketList(jsObject, start, end, filter));
        }

        public async Task UpdateCache([FromServices] CacheHostedService cache)
        {
            await cache.StartAsync(new System.Threading.CancellationToken(false));
            return;

        }

        public string GetSerializedResultAsync(Filter filter, DateTime start, DateTime end)
        {
            List<string> jiraIssuesList = new List<string>() { Constants.FinasDefect, Constants.FeplasDefect, Constants.SafirDefect };
            List<IPolarionTicket> ticketList = new List<IPolarionTicket>();
            for (int i = 0; i < jiraIssuesList.Count(); i++)
            {
                JObject jsObject = _jiraConfiguration.KnownTasks[jiraIssuesList[i]];
                if (filter.ShowUsers)
                {
                    ticketList.AddRange(report.CreateDetailedPolarionTicketList(jsObject, start, end, filter));
                }
                else
                {
                    ticketList.AddRange(report.CreatePolarionTicketList(jsObject, start, end, filter));
                }
            }
            return JsonConvert.SerializeObject(ticketList);
        }

        public string GetSerializedResultNewTech(Filter filter, DateTime start, DateTime end)
        {
            List<string> jiraIssuesList = new List<string>() { Constants.NewTechMicroServices, Constants.NewTechMigration, Constants.NewTechTesting };
            List<IPolarionTicket> ticketList = new List<IPolarionTicket>();
            for (int i = 0; i < jiraIssuesList.Count(); i++)
            {
                JObject jsObject = _jiraConfiguration.KnownTasks[jiraIssuesList[i]];
                if (filter.ShowUsers)
                {
                    ticketList.AddRange(report.CreateDetailedPolarionTicketList(jsObject, start, end, filter));
                }
                else
                {
                    ticketList.AddRange(report.CreatePolarionTicketList(jsObject, start, end, filter));
                }
            }
            return JsonConvert.SerializeObject(ticketList);
        }

        public string GetSerializedResultNewTechByIssue(Filter filter, DateTime start, DateTime end)
        {
            List<string> jiraIssuesList = new List<string>() { Constants.NewTechMicroServices, Constants.NewTechMigration, Constants.NewTechTesting };
            List<IPolarionTicket> ticketList = new List<IPolarionTicket>();
            List<IPolarionTicket> issueList = new List<IPolarionTicket>();

            for (int i = 0; i < jiraIssuesList.Count(); i++)
            {
                JObject jsObject = _jiraConfiguration.KnownTasks[jiraIssuesList[i]];
                ticketList.AddRange(report.CreatePolarionTicketList(jsObject, start, end, filter));
            }

            Dictionary<string, decimal> ListIssues = setDictionary();
            Dictionary<string, decimal> Issues = setDictionary();

            foreach (var elem in ListIssues)
            {
                foreach (var item in ticketList)
                {
                    if (item.CompleteName.ToLower().Contains(elem.Key) || item.CompleteName.ToLower().Contains(elem.Key.Replace("_", "")))
                    {
                        Issues[elem.Key] += item.TimeSpent;
                    }
                }
            }

            foreach (var elem in Issues)
            {
                issueList.Add(new PolarionTicket
                {
                    TimeSpent = elem.Value,
                    CompleteName = elem.Key
                });
            }

            Console.WriteLine(Issues);

            return JsonConvert.SerializeObject(issueList);
        }

        private Dictionary<string, decimal> setDictionary()
        {
            Dictionary<string, decimal> Issues = new Dictionary<string, decimal>();
            Issues.Add("wsp_052", 0);
            Issues.Add("wsp_053", 0);
            Issues.Add("wsp_055", 0);
            Issues.Add("wsp_056", 0);
            Issues.Add("wsp_064", 0);
            Issues.Add("wsp_085", 0);
            Issues.Add("wsp_999", 0);
            Issues.Add("gen_001", 0);
            Issues.Add("gen_002", 0);
            Issues.Add("gen_008", 0);
            Issues.Add("gen_010", 0);
            Issues.Add("gen_011", 0);
            Issues.Add("gen_013", 0);
            Issues.Add("gen_016", 0);
            Issues.Add("gen_017", 0);
            Issues.Add("wsp_004", 0);
            Issues.Add("wsp_036f", 0);
            Issues.Add("wsp_036o", 0);
            Issues.Add("wsp_037f", 0);
            Issues.Add("wsp_037o", 0);
            Issues.Add("wsp_038f", 0);
            Issues.Add("wsp_038o", 0);
            Issues.Add("wsp_039f", 0);
            Issues.Add("wsp_039o", 0);
            Issues.Add("wsp_040", 0);
            Issues.Add("wsp_041", 0);
            Issues.Add("wsp_042", 0);
            Issues.Add("wsp_054", 0);
            Issues.Add("wsp_060", 0);
            Issues.Add("wsp_062", 0);
            Issues.Add("wsp_063", 0);
            Issues.Add("wsp_070", 0);
            Issues.Add("wsp_072", 0);
            Issues.Add("wsp_073", 0);
            Issues.Add("wsp_074", 0);
            Issues.Add("wsp_075", 0);
            Issues.Add("wsp_077", 0);
            Issues.Add("gen_003", 0);
            Issues.Add("gen_004", 0);
            Issues.Add("gen_005", 0);
            Issues.Add("gen_006", 0);
            Issues.Add("gen_007", 0);
            Issues.Add("gen_009", 0);
            Issues.Add("gen_012", 0);
            Issues.Add("gen_014", 0);

            return Issues;
        }

        public async Task<string> GetSerializedResultAsync(DateTime start, DateTime end, List<string> jiraIssuesIds)
        {
            List<JiraIssue> jiraIssuesList = new List<JiraIssue>();
            for (int i = 0; i < jiraIssuesIds.Count() - 1; i++)
            {
                JObject jsObjectForName;
                if (_jiraConfiguration.KnownTasks.ContainsKey(jiraIssuesIds[i]))
                {
                    jsObjectForName = _jiraConfiguration.KnownTasks[jiraIssuesIds[i]];
                }
                else
                {
                    jsObjectForName = JObject.Parse(await jsonCreator.GetJiraWorklogAsync(jiraIssuesIds[i]));
                    _jiraConfiguration.KnownTasks.Add(jiraIssuesIds[i], jsObjectForName);
                }

                string name = jsObjectForName["fields"]["summary"].ToString();

                JObject jsObject = JObject.Parse(await jsonCreator.GetJiraWorklogAsync(jiraIssuesIds[i]));
                IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo =
                                    dataCreator.CreateQueryForDetailedTicket(jsObject, start, end);
                decimal hours = report.GetTotalTimeSpentOnJiraIssue(ticketsInfo);
                jiraIssuesList.Add(new JiraIssue() { CompleteName = name, TimeSpent = hours });
            }
            return JsonConvert.SerializeObject(jiraIssuesList);
        }

        public NetworkCredential GetCredentials()
        {
            return jsonCreator.GetCred();
        }
    }
}