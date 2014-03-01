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
        readonly IEnrollRepository _enroll;
        readonly ISessionRepository _sess;

        public HomeController(IUserRepository userRepo, ISessionRepository sessionRepo, IEnrollRepository enrollRepo)
        {
            _user = userRepo;
            _sess = sessionRepo;
            _enroll = enrollRepo;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            User currentUser =  _user.GetUserByEmail(User.Identity.Name);
            return View(currentUser);
        }

        //
        // GET: /Profile/
        public ActionResult Profile()
        {
            User currentUser = _user.GetUserByEmail(User.Identity.Name);
            return View(currentUser);
        }

        public ActionResult Enroll()
        {
            User currentUser = _user.GetUserByEmail(User.Identity.Name);
            var availableSessions = _sess.GetAvailableSessions();
            return View(availableSessions);
        }

        [HttpPost]
        public ActionResult Enroll(int sessionId)
        {

        }

    }
}
