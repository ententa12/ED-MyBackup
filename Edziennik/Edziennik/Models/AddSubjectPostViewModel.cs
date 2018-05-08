using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class AddSubjectPostViewModel
    {
        public int ID_Class { get; set; }
        public int ? ID_Group { get; set; }
        public int ID_Teaher { get; set; }
        public string Name { get; set; }

    }
}