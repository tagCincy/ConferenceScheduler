using ConferenceScheduler.Models.Abstract;
using ConferenceScheduler.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConferenceScheduler.Models.Concrete
{
    public class UserRepository : IUserRepository
    {
        ConferenceContext context = new ConferenceContext();

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Where(s => s.EmailAddress == email).FirstOrDefault();
        }

        public bool CreateUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}