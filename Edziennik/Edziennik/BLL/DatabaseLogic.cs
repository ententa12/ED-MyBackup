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

        public void AddPerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Event;
        }

        public IEnumerable<Event> GetEventsForStudent(Person person)
        {
            return GetAllEvents().Where(p=>p.Class1 == person.Class);
        }

        public IEnumerable<Event> GetEventsForTeaher(Person person)
        {
            return GetAllEvents().Where(p => p.Person == person);
        }

        public void AddLogin(Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
        }

        public void ChangePassword(Login loginWithNewPass)
        {
            GetLogin(loginWithNewPass.Login1).Password = loginWithNewPass.Password;
            _context.SaveChanges();
        }

        public Person GetPerson(int id)
        {
            return _context.Person.Where(p=>p.ID_Person == id).FirstOrDefault();
        }

        public Login GetLogin(string login)
        {
            return _context.Login.Where(p => p.Login1 == login).FirstOrDefault();
        }
    }
}