using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public struct GradeForVM
    {
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Grade { get; set; }

    }
    public class GradesBySubject
    {
        public string StudentName { get; set; }
        public List<GradeForVM> Grades { get; set; }
        public GradesBySubject()
        {
            Grades = new List<GradeForVM>();
        }
        public GradesBySubject(List<Grade> grades) : this()
        {
            foreach (var item in grades)
            {
                Grades.Add(new GradeForVM() {
                    Status = item.Status,
                    Date = item.Date,
                    Grade = item.Grade1
                });
            }
        }
    }
}