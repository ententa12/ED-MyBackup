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
    public class SubjectController : Controller
    {
        DatabaseLogic db;
        public SubjectController()
        {
            db = new DatabaseLogic();
        }
        //GET
        public string AddSubject()
        {
            var model = new AddSubjectGetViewModel();
            var classes = db.GetClasses().Select(p => new Models.Class()
            {
                Id = p.ID_Class,
                Name = p.Name
            });
            model.Classes.AddRange(classes);
            var groups = db.GetGroups().Select(p => new Models.Group()
            {
                Id = p.ID_Gruop,
                Name = p.Name
            });
            model.Groups.AddRange(groups);
            var teahers = db.GetTeahers().Select(p => new Models.Teaher()
            {
                Id = p.ID_Person,
                FirstName = p.FirstName,
                LastName = p.LastName
            });
            model.Teahers.AddRange(teahers);

            return JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string AddSubject(string jsonString = "{\"id_class\":\"2\",\"id_group\":\"\",\"id_teaher\":\"1\",\"name\":\"Francuski\"}")
        {
            AddSubjectPostViewModel addSubject = JsonConvert.DeserializeObject<AddSubjectPostViewModel>(jsonString);
            Subject s = new Subject()
            {
                Person = db.GetPerson(addSubject.ID_Teaher),
                Group = addSubject.ID_Group != null ? db.GetGroup(addSubject.ID_Group):null,
                Class = db.GetClass(addSubject.ID_Class),
                Name = addSubject.Name
            };
            db.AddSubject(s);
            return "Dodano";
        }

        struct GetID
        {
            public int ID{ get; set; }
        }

        public string GetSubjectByTeaher(string jsonString = "{\"id\":\"1\"}")
        {
            var teaher_id = JsonConvert.DeserializeObject<GetID>(jsonString);
            var model = db.GetPerson(teaher_id.ID).Subject.Select(p => new SubjectViewModel() {
                ID = p.ID_Subject,
                ClassName = p.Class.Name,
                GroupName = p.Group != null ? p.Group.Name : string.Empty,
                Name = p.Name
            });
            return JsonConvert.SerializeObject(model);
        }

        public string GetGradesBySubject(string jsonString)
        {
            var subject_id = JsonConvert.DeserializeObject<GetID>(jsonString);
            var sub = db.GetSubject(subject_id.ID);
            var model = sub.Class.Person.Select(p => new GradesBySubject(p.Grade.Where(d=>d.Subject.ID_Subject == sub.ID_Subject).ToList()) {
                StudentName = p.FirstName + " " + p.LastName
            });

            return JsonConvert.SerializeObject(model);
        }
    }
}