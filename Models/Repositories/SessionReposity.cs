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
    }
}