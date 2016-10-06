using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}