using ConferenceScheduler.Models.DAL;
using ConferenceScheduler.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConferenceScheduler.Models.Repositories
{
    public class EnrollRepository : IEnrollRepository
    {
        readonly ConferenceContext _context = new ConferenceContext();

        public IEnumerable<Session> GetUserSessions(int userId)
        {
            List<Session> userSessions = new List<Session>();
            var sessions = _context.Enrollments.Where(c => c.UserID == userId);

            return null;
        }

        public IEnumerable<User> GetSessionUsers(int sessionId)
        {
            throw new NotImplementedException();
        }
    }
}