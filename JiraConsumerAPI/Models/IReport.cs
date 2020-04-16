using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace JiraConsumerAPI.Models
{
    public interface IReport
    {
        List<IPolarionTicket> CreatePolarionTicketList(JObject jsObject, DateTime start, DateTime end, Filter filter);
        List<IPolarionTicket> CreateDetailedPolarionTicketList(JObject jsObject, DateTime start, DateTime end, Filter filter);
        decimal GetTotalTimeSpentOnJiraIssue(IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo);
    }
}
