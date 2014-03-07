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

            if(session.Users == null || !session.Users.Contains(currentUser))
            {
                session.Users.Add(_context.Users.Find(currentUser.UserID));
                _context.SaveChanges();

                if(session.Occupancy == session.Users.Count)
                {
                    session.IsFull = true;
                    _context.SaveChanges();
                }
                
                return true;
            }

            return false;
        }
    }
}