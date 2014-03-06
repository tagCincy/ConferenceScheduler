using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceScheduler.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(AdminLogin al)
        {
            return View();
        }
        //
        // GET: /Admin/Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
