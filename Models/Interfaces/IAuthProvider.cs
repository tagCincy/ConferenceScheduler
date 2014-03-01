using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Models.Interfaces
{
    public interface IAuthProvider
    {
        bool Authenticate(UserLogin l);
        int GetCurrentUserId(string email);
    }
}
