using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace JiraConsumerAPI.Extensions
{
    public interface IDataCreator
    {
        public IEnumerable<(JToken Comment, JToken TimeSpentSeconds)> CreateQuery(JObject jsObject, DateTime start, DateTime end);

        public IEnumerable<(JToken UserId, JToken Comment, JToken TimeSpentSeconds)> CreateQueryForDetailedTicket(JObject jsObject, DateTime start, DateTime end);
    }
}
