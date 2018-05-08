using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Edziennik.BLL
{
    public class DatabaseLogic
    {
        SchoolDatabaseEntities1 _context;

        public DatabaseLogic()
        {
            _context = new SchoolDatabaseEntities1();
        }

        #region Get
        public IEnumerable<Person> GetPeople()
        {
            return _context.Person;
        }
        public IEnumerable<Person> GetTeahers()
        {
            return _context.Person.Where(p => p.Status == "Nauczyciel");
        }
        public IEnumerable<Class> GetClasses()
        {
            return _context.Class;
        }
        public IEnumerable<Group> GetGroups()
        {
            return _context.Group;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Event;
        }

        public IEnumerable<Event> GetEventsForStudent(Person person)
        {
            return GetAllEvents().Where(p => p.Class1 == person.Class);
        }

        public IEnumerable<Event> GetEventsForTeaher(Person person)
        {
            return GetAllEvents().Where(p => p.Person == person);
        }
        public IEnumerable<Presence> GetPresences(Person person)
        {
            return _context.Presence.Where(p => p.Person == person);
        }

        public Class GetClass(int id)
        {
            return _context.Class.Find(id);
        }
        public Group GetGroup(int? id)
        {
            return _context.Group.Find(id);
        }


        public Person GetPerson(int id)
        {
            return _context.Person.Where(p => p.ID_Person == id).FirstOrDefault();
        }

        public Login GetLogin(string login)
        {
            return _context.Login.Where(p => p.Login1 == login).FirstOrDefault();
        }

        public Subject GetSubject(int id)
        {
            return _context.Subject.Find(id);
        }
        #endregion

        #region Add
        public void AddPerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }


        public void AddLogin(Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
        }


        public void AddSubject(Subject s)
        {
            _context.Subject.Add(s);
            _context.SaveChanges();
        }
        #endregion

        #region Modyfication
        public void ChangePassword(Login loginWithNewPass)
        {
            GetLogin(loginWithNewPass.Login1).Password = loginWithNewPass.Password;
            _context.SaveChanges();
        }

        #endregion
    }
}