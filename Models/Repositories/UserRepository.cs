using ConferenceScheduler.Models.Interfaces;
using ConferenceScheduler.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceScheduler.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ConferenceContext _context = new ConferenceContext();

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(s => s.EmailAddress == email);
        }

        public User CreateUser(User u)
        {
            User newUser = _context.Users.Add(u);
            _context.SaveChanges();
            return newUser;
        }

        public User UpdateUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}