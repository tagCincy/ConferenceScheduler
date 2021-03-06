﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Models.Interfaces
{
    public interface ISessionRepository
    {
        IEnumerable<Session> GetAvailableSessions();

        Session GetSessions(int id);

        bool AddUserToSession(int id, User currentUser);
    }
}
