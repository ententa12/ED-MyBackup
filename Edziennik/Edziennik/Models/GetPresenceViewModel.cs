using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class GetPresenceViewModel
    {
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string NameTeacher { get; set; }
        public string Subject { get; set; }
    }
}