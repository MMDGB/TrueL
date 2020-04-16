using Newtonsoft.Json;

namespace JiraConsumerAPI.Models
{
    public class PolarionTicket : IPolarionTicket
    {
        [JsonIgnore]
        public Filter Filter { get; set; }
        [JsonIgnore]
        public IComment Name { get; set; }
        public string UserId { get; set; }
        public decimal TimeSpent { get; set; }
        public string CompleteName { get; set; }


        public bool ShouldSerializeUserId()
        {
            if (Filter != null)
                return Filter.ShowUsers;
            else
                return false;
        }

    }
}