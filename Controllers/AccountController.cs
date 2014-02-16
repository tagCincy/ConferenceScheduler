using ConferenceScheduler.Models;
using ConferenceScheduler.Models.Abstract;
using ConferenceScheduler.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ConferenceScheduler.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider _auth;

        public AccountController(IAuthProvider authProvider)
        {
            _auth = authProvider;
        }

        public ActionResult Login(string returnUrl)
        {
            UserLogin l = new UserLogin { ReturnUrl = returnUrl };
            return View(l);
        }

        [HttpPost]
        public ActionResult Login(UserLogin l)
        {
            if(ModelState.IsValid)
            {
                bool isTrue = _auth.Authenticate(l);
                if(isTrue)
                {
                    FormsAuthentication.SetAuthCookie(l.Email, false);
                    return Redirect(l.ReturnUrl);
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
