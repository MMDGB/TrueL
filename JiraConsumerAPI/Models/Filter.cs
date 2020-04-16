using System.Text.Json.Serialization;

namespace JiraConsumerAPI.Models
{
    public class Filter
    {
        [JsonPropertyName("isPolarion")]
        public bool IsPolarion { get; set; }

        [JsonPropertyName("showUsers")]
        public bool ShowUsers { get; set; }
    }
}
