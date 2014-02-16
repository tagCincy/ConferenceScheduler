using ConferenceScheduler.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ConferenceScheduler.Models.Concrete
{
    class AuthProvider : IAuthProvider
    {
        IUserRepository _ur;

        public AuthProvider(IUserRepository userRepo)
        {
            _ur = userRepo;
        }

        public bool Authenticate(UserLogin l)
        {
            var user = _ur.GetUserByEmail(l.Email);

            if(user != null)
            {
                if (user.Password.Equals(l.Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}