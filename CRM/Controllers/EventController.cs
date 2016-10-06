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
    public class EventController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET
        [HttpGet]
        [ActionName("GetEvents")]
        public string GetEvents()
        {
            List<Event> events = new List<Event>();
            foreach (Event e in db.Events.ToList())
            {
                events.Add(new Event()
                {
                    EventID = e.EventID,
                    CourseID = e.CourseID,
                    StudentID = e.StudentID,
                    EventDate = e.EventDate
                });
            }

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(events);
        }

        //Add or edit
        [HttpPost]
        [ActionName("PostEvent")]
        public IHttpActionResult PostEvent(Event e)
        {
            //edit
            if (e.EventID != 0)
            {
                System.Diagnostics.Debug.WriteLine(e.EventDate);
                db.Entry(e).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(e.EventID))
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
                db.Events.Add(e);
                db.SaveChanges();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete
        [HttpPost]
        [ActionName("DeleteEvent")]
        public IHttpActionResult DeleteEvent(Event obj)
        {
            Event e = db.Events.Find(obj.EventID);
            if (e == null)
            {
                return NotFound();
            }

            db.Events.Remove(e);
            db.SaveChanges();

            return Ok(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.EventID == id) > 0;
        }
    }
}