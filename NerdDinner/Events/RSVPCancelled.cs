using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Events
{
    public class RSVPCancelled : IEventData
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public int DinnerId { get; set; }
    }
}