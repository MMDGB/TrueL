using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraConsumerAPI.Extensions
{
    public class DataCreator : IDataCreator
    {
        public IEnumerable<(JToken Comment, JToken TimeSpentSeconds)> CreateQuery(JObject jsObject, DateTime start, DateTime end)
        {
            try
            {
                IEnumerable<(JToken Comment, JToken TimeSpentSeconds)> ticketsInfo =
           from objects in jsObject["worklogs"]
           let Comment = objects["comment"]
           let TimeSpentSeconds = objects["timeSpentSeconds"]
           where (DateTime)objects["created"] >= start
           && (DateTime)objects["created"] <= end
           orderby Comment
           select (
               Comment,
               TimeSpentSeconds
               );
                return ticketsInfo;

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> CreateQueryForDetailedTicket(JObject jsObject, DateTime start, DateTime end)
        {
            IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> ticketsInfo =
               from objects in jsObject["worklogs"]
               let UserId = objects["author"]["name"]
               let Comment = objects["comment"]
               let TimeSpentSeconds = objects["timeSpentSeconds"]
               where (DateTime)objects["created"] >= start
               && (DateTime)objects["created"] <= end
               orderby Comment orderby UserId
               select (
                   UserId,
                   Comment,
                   TimeSpentSeconds
               );
            return ticketsInfo;
        }
    }
}
