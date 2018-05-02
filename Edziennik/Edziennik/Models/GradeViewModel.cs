using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class GradeViewModel
    {
        public string Grade { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string NameTeacher { get; set; }
        public string Subject { get; set; }

    }
}