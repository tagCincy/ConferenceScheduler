using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceScheduler.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int UserID { get; set; }
        public int SessionID { get; set; }

        public virtual User User { get; set; }
        public virtual Session Session { get; set; }

    }
}
