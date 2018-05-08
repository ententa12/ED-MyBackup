using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Data { get; set; }
        public DateTime ? EndDate { get; set; }

    }
}