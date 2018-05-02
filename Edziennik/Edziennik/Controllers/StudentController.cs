using Edziennik.BLL;
using Edziennik.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edziennik.Controllers
{
    public class StudentController : Controller
    {
        DatabaseLogic db;
        public StudentController()
        {
            db = new DatabaseLogic();
        }
        struct ID
        {
            public int Id { get; set; }
        }
        // GET: Student
        public string GetPresence(string jsonString)
        {
            var Id = JsonConvert.DeserializeObject<ID>(jsonString);
            var person = db.GetPerson(Id.Id);
            IEnumerable<GetPresenceViewModel> presenceToSend = person.Presence.Select(p => new GetPresenceViewModel() {
                Status = p.Status,
                Date = p.Lesson.Date,
                Time = p.Lesson.Hour,
                NameTeacher = p.Lesson.Person.FirstName + " " + p.Lesson.Person.LastName,
                Subject = p.Lesson.Subject.Name
            });

            return JsonConvert.SerializeObject(presenceToSend);
        }
        public string GetNotes(string jsonString)
        {
            var Id = JsonConvert.DeserializeObject<ID>(jsonString);
            var person = db.GetPerson(Id.Id);
            IEnumerable<NoteViewModel> notesToSend = person.Note.Select(p => new NoteViewModel()
            {
                Status = p.Status,
                Descryption = p.Descryption,
                NameTeacher = p.Person1.FirstName + " " + p.Person1.LastName
            });

            return JsonConvert.SerializeObject(notesToSend);
        }
        public string GetGrades(string jsonString)
        {
            var Id = JsonConvert.DeserializeObject<ID>(jsonString);
            var person = db.GetPerson(Id.Id);
            IEnumerable<GradeViewModel> gradesToSend = person.Grade.Select(p => new GradeViewModel()
            {
                Status = p.Status,
                Date = p.Date,
                Grade = p.Grade1,
                Subject = p.Subject.Name,
                NameTeacher = p.Subject.Person.FirstName + " " + p.Subject.Person.LastName
            });

            return JsonConvert.SerializeObject(gradesToSend);
        }
    }
}