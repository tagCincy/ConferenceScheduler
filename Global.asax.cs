using ConferenceScheduler.Models.Interfaces;
using ConferenceScheduler.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConferenceScheduler
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        IUserRepository _user;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            _user = new UserRepository();

            if(Request.IsAuthenticated)
            {
                var user = _user.GetUserByEmail(Context.User.Identity.Name);

                if(user != null)
                {
                    Context.User = new GenericPrincipal(
                        new GenericIdentity(Context.User.Identity.Name),
                        user.Roles.Select(r => r.Name).ToArray()
                        );
                }
            }
            
        }
    }
}