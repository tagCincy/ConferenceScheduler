using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Models.Interfaces
{
    public interface IEnrollRepository
    {
        IEnumerable<Session> GetUserSessions(int userId);
        IEnumerable<User> GetSessionUsers(int sessionId);
    }
}
