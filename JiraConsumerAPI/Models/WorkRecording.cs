using System.Collections.Generic;

namespace JiraConsumerAPI.Models
{
    public class WorkRecording
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        public List<IPolarionTicket> TicketList { get; set; }
    }
}