using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConferenceScheduler.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public int Occupancy { get; set; }
        public Boolean IsFull { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}