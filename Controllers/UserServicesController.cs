using ConferenceScheduler.Models;
using ConferenceScheduler.Models.DAL;
using ConferenceScheduler.Models.Interfaces;
using ConferenceScheduler.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConferenceScheduler.Controllers
{
    public class UserServicesController : ApiController
    {
        readonly IUserRepository _ur;

        public UserServicesController()
        {
            _ur = new UserRepository();
        }
        public User[] GetUsers()
        {
            return _ur.GetAllUsers().ToArray();
        }
    }
}
