using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public struct Teaher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
    }
    public struct Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public struct Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AddSubjectGetViewModel
    {
        public List<Teaher> Teahers { get; set; }
        public List<Class> Classes { get; set; }
        public List<Group> Groups { get; set; }

        public AddSubjectGetViewModel()
        {
            Teahers = new List<Teaher>();
            Classes = new List<Class>();
            Groups = new List<Group>();
        }
    }
}