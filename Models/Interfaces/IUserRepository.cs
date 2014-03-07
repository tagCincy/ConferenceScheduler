using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
        User CreateUser(User u);
        User UpdateUser(User u);
        bool DeleteUser(int id);
    }
}
