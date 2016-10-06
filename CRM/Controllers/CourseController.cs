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
    public class CourseController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET
        [HttpGet]
        [ActionName("GetCourses")]
        public string GetCourses()
        {
            List<Course> courses = new List<Course>();
            foreach (Course c in db.Courses.ToList())
            {
                courses.Add(new Course()
                {
                    CourseID = c.CourseID,
                    Title = c.Title
                });
            }

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(courses);
        }

        //Add or edit
        [HttpPost]
        [ActionName("PostCourse")]
        public IHttpActionResult PostCourse(Course course)
        {
            //edit
            if (course.CourseID != 0)
            {
                db.Entry(course).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
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
                db.Courses.Add(course);
                db.SaveChanges();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete
        [HttpPost]
        [ActionName("DeleteCourse")]
        public IHttpActionResult DeleteCourse(Course obj)
        {
            Course course = db.Courses.Find(obj.CourseID);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.CourseID == id) > 0;
        }
    }
}