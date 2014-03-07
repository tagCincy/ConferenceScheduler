using System.Web.Mvc;
using ConferenceScheduler.Models;
using ConferenceScheduler.Models.Interfaces;
using System.Collections.Generic;

namespace ConferenceScheduler.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly IUserRepository _user;

        public HomeController(IUserRepository userRepo)
        {
            _user = userRepo;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            User currentUser = _user.GetUserByEmail(User.Identity.Name);
            return View(currentUser);
        }
    }
}
