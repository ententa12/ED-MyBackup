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
    public class EventGetController : Controller
    {
        DatabaseLogic db;
        public EventGetController()
        {
            db = new DatabaseLogic();
        }
        struct ID
        {
            public int Id { get; set; }
        }
        // GET: Student
        public string GetEvents(string jsonString)
        {
            var Id = JsonConvert.DeserializeObject<ID>(jsonString);
            var person = db.GetPerson(Id.Id);

            if (person.Status == "Nauczyciel")
            {
                IEnumerable<EventViewModel> events = db.GetEventsForTeaher(person).Select(p =>
                new EventViewModel()
                {
                    Category = p.Category,
                    Description = p.Description,
                    Title = p.Title,
                    Data = p.Data
                });
                return JsonConvert.SerializeObject(events);
            }
            else if (person.Status == "Uczeń")
            {
                IEnumerable<EventViewModel> events = db.GetEventsForStudent(person).Select(p =>
                new EventViewModel()
                {
                    Category = p.Category,
                    Description = p.Description,
                    Title = p.Title,
                    Data = p.Data
                });
                return JsonConvert.SerializeObject(events);
            }

            return "";
        }
    }
}