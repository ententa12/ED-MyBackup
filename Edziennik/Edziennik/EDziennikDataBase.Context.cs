﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Edziennik
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolDatabaseEntities1 : DbContext
    {
        public SchoolDatabaseEntities1()
            : base("name=SchoolDatabaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Presence> Presence { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectInPlan> SubjectInPlan { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
