using JiraConsumerAPI.Extensions;
using JiraConsumerAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraConsumerAPI.Models
{
    public class Report : IReport
    {
        private readonly IDataCreator dataCreator;
        private readonly IParser parser;
        private List<IPolarionTicket> ticketList;


        public Report()
        {
            dataCreator = new DataCreator();
            ticketList = new List<IPolarionTicket>();
            parser = new Parser();
        }

        public List<IPolarionTicket> CreatePolarionTicketList(JObject jsObject, DateTime start, DateTime end, Filter filter)
        {
            IEnumerable<(JToken Comment, JToken TimeSpentSeconds)> ticketsInfo = dataCreator.CreateQuery(jsObject, start, end);
            AddTicketToList(filter, ticketsInfo);
            ticketList = ticketList.OrderByDescending(t => t.TimeSpent).ToList();
            return ticketList;
        }

        public List<IPolarionTicket> CreateDetailedPolarionTicketList(JObject jsObject, DateTime start, DateTime end, Filter filter)
        {
            IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo =
                dataCreator.CreateQueryForDetailedTicket(jsObject, start, end);
            AddDetailedTicketToList(filter, ticketsInfo);
            ticketList = ticketList.OrderByDescending(t => t.Name.Base).ThenByDescending(t => t.TimeSpent).ToList();
            return ticketList;
        }

        public decimal GetTotalTimeSpentOnJiraIssue(IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo)
        {
            decimal totalTimeSpent = 0;
            for (int i = 0; i < ticketsInfo.Count() - 1; i++)
            {
                totalTimeSpent += parser.SecondsToHours(Convert.ToInt64(ticketsInfo.ElementAt(i).TimeSpentSeconds));
            }
            return totalTimeSpent;
        }

        private void AddTicketToList(Filter filter, IEnumerable<(JToken Comment, JToken TimeSpentSeconds)> ticketsInfo)
        {
            for (int i = 0; i < ticketsInfo.Count() - 1; i++)
            {
                decimal timeSpent = parser.SecondsToHours(Convert.ToInt64(ticketsInfo.ElementAt(i).TimeSpentSeconds));
                string[] comments = parser.GetComment(ticketsInfo.ElementAt(i).Comment.ToString(), filter.IsPolarion);

                if (comments != null && comments.Count() > 0)
                {
                    int j = i;
                    while (j < ticketsInfo.Count() - 1 && ticketsInfo.ElementAt(j + 1).Comment.ToString().StartsWith(comments[0]))
                    {
                        timeSpent += parser.SecondsToHours(Convert.ToInt64(ticketsInfo.ElementAt(j + 1).TimeSpentSeconds));
                        j++;
                    }
                    i = j;
                    IPolarionTicket ticket = new PolarionTicket
                    {
                        TimeSpent = timeSpent,
                        Name = new Comment(comments),
                        Filter = filter,
                    };
                    ticket.CompleteName = ticket.Name.Base + ticket.Name.PolarionExtension;
                    ticketList.Add(ticket);
                }
            }
        }

        private void AddDetailedTicketToList(Filter filter, IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo)
        {
            for (int i = 0; i < ticketsInfo.Count() - 1; i++)
            {
                decimal timeSpent = parser.SecondsToHours(Convert.ToInt64(ticketsInfo.ElementAt(i).TimeSpentSeconds));
                string[] comments = parser.GetComment(ticketsInfo.ElementAt(i).Comment.ToString(), filter.IsPolarion);
                string userId = ticketsInfo.ElementAt(i).UserId.ToString();
                if (comments != null && comments.Count() > 0)
                {
                    int j = i;
                    while (j < ticketsInfo.Count() - 1 
                        && ticketsInfo.ElementAt(j + 1).Comment.ToString().StartsWith(comments[0]) 
                        && userId.Equals(ticketsInfo.ElementAt(j + 1).UserId.ToString()))
                    {
                        timeSpent += parser.SecondsToHours(Convert.ToInt64(ticketsInfo.ElementAt(j + 1).TimeSpentSeconds));
                        j++;
                    }
                    i = j;
                    IPolarionTicket ticket = new PolarionTicket
                    {
                        UserId = userId,
                        TimeSpent = timeSpent,
                        Name = new Comment(comments),
                        Filter = filter,
                    };
                    ticket.CompleteName = ticket.Name.Base + ticket.Name.PolarionExtension;
                    ticketList.Add(ticket);
                }
            }
        }
    }
}
