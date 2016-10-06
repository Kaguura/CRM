using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;
using System.Data.Entity;

namespace CRM.DAL
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Sholpan",LastName="Bimanova"},
            new Student{FirstName="Damira",LastName="Bulatova"},
            new Student{FirstName="Nazym",LastName="Sajbek"},
            new Student{FirstName="Gulnur",LastName="Omyrserikkyzy"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{Title="Health and Labor safety"},
            new Course{Title="Software testing"},
            new Course{Title="Big data"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var events = new List<Event>
            {
            new Event{StudentID=1,CourseID=2,EventDate=DateTime.Parse("2016-11-01")},
            new Event{StudentID=4,CourseID=1,EventDate=DateTime.Parse("2016-10-12")},
            new Event{StudentID=1,CourseID=3,EventDate=DateTime.Parse("2017-02-25")},
            new Event{StudentID=3,CourseID=1,EventDate=DateTime.Parse("2017-03-17")}
            };
            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
        }
    }
}