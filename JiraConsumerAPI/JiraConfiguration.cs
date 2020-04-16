using JiraConsumerAPI.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiraConsumerAPI
{
    internal class JiraConfiguration : IJiraConfiguration
    {
        public Dictionary<string, JObject> KnownTasks { get; set; }
        public DateTime LastFetched { get; set; }

        public async Task UpdateKnownTasks()
        {
            JsonCreator jsonCreator = new JsonCreator();
            Dictionary<string, JObject> cachedValues = new Dictionary<string, JObject>();

            foreach (var item in KnownTasks)
            {
                cachedValues.Add(item.Key, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(item.Key)));  
            }

            KnownTasks = cachedValues;
        }
    }
}