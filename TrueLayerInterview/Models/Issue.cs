using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueLayerInterview.Models;

namespace TrueLayerInterview
{
    public class Issue
    {
        public long Id { get; set; }
        public string TicketName { get; set; }
        public Employee TicketAssigne { get; set; }
        public string Status { get; set; }
    }
}
