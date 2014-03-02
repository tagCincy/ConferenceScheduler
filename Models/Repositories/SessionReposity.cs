using ConferenceScheduler.Models.DAL;
using ConferenceScheduler.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConferenceScheduler.Models.Repositories
{
    public class SessionReposity : ISessionRepository
    {
        readonly ConferenceContext _context = new ConferenceContext();

        public IEnumerable<Session> GetAvailableSessions()
        {
            return _context.Sessions.Where(x => x.IsFull == false);
        }


        public Session GetSessions(int id)
        {
            Session session = _context.Sessions.Find(id);
            return session;
        }

        public bool AddUserToSession(int id, User currentUser)
        {
            Session session = _context.Sessions.Find(id);
            var isEnrolled = _context.Enrollments.Where(e => e.SessionID == session.SessionID).Where(e => e.UserID == currentUser.UserID).FirstOrDefault();

            if (isEnrolled == null)
            {
                Enrollment enrollment = new Enrollment
                {
                    SessionID = session.SessionID,
                    UserID = currentUser.UserID
                };

                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();

                if (enrollment != null)
                {
                    IEnumerable<Enrollment> sessionEnrollment = _context.Enrollments.Where(e => e.SessionID == session.SessionID);
                    int sessionOccupancy = session.Occupancy;

                    if (sessionEnrollment.Count() == sessionOccupancy)
                    {
                        session.IsFull = true;
                        _context.SaveChanges();
                    }

                    return true;
                }
            }

            return false;
        }
    }
}