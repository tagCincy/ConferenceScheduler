using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceScheduler.Models.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
        bool CreateUser(User u);
        bool UpdateUser(User u);
        bool DeleteUser(int id);
    }
}
