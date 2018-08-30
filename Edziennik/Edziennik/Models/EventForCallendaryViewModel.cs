using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class EventForCallendaryViewModel
    {
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
    }
}