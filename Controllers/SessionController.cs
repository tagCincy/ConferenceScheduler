using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConferenceScheduler.Models;
using ConferenceScheduler.Models.DAL;
using ConferenceScheduler.Models.Interfaces;

namespace ConferenceScheduler.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        readonly ISessionRepository _sess;
        readonly IUserRepository _user;

        public SessionController(ISessionRepository sessionRepo, IUserRepository userRepo)
        {
            _sess = sessionRepo;
            _user = userRepo;
        }

        //
        // GET: /Session/

        public ActionResult Index()
        {
            IEnumerable<Session> sessions = _sess.GetAvailableSessions();
            return View(sessions);
        }

        //
        // GET: /Session/Details/5

        public ActionResult Details(int id)
        {
            Session session = _sess.GetSessions(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        //
        // GET: /Session/Enroll/5
        public ActionResult Enroll(int id)
        {
            User currentUser = _user.GetUserByEmail(User.Identity.Name);
            bool enrolled = _sess.AddUserToSession(id, currentUser);

            if (enrolled)
            {
                TempData["success"] = "Enrolled!";
                return RedirectToAction("Index", "Home");
            }

           TempData["error"] = "Cannot Enroll User";
            return RedirectToAction("Index", "Session");
        }
    }
}