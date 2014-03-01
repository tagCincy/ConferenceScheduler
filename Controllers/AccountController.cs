using ConferenceScheduler.Models;
using ConferenceScheduler.Models.Interfaces;
using System.Web.Mvc;
using System.Web.Security;

namespace ConferenceScheduler.Controllers
{
    public class AccountController : Controller
    {
        readonly IAuthProvider _auth;

        public AccountController(IAuthProvider authProvider)
        {
            _auth = authProvider;
        }

        public ActionResult Login(string returnUrl)
        {
            var l = new UserLogin { ReturnUrl = returnUrl };
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
                return View();
            }
            return View();
        }
    }
}
