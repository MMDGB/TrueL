using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JiraConsumerAPI
{
    public interface IJiraConfiguration
    {
        Dictionary<string, JObject> KnownTasks { get; set; }
        Task UpdateKnownTasks();
    }
}