using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRM.DAL;
using CRM.Models;

namespace CRM.Controllers
{

    public class StudentController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        [ActionName("GetStudents")]
        public string GetStudents()
        {
            List<Student> students = new List<Student>();
            foreach (Student s in db.Students.ToList())
            {
                students.Add(new Student()
                {
                    ID = s.ID,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                });
            }

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(students);
        }

        //Add or edit
        [HttpPost]
        [ActionName("PostStudent")]
        public IHttpActionResult PostStudent(Student student)
        {
            //edit
            if (student.ID != 0)
            {
                db.Entry(student).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //Add
            else
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete
        [HttpPost]
        [ActionName("DeleteStudent")]
        public IHttpActionResult DeleteStudent(Student obj)
        {
            Student student = db.Students.Find(obj.ID);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}