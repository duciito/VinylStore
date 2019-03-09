using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VinylStore.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["loggedUser"] != null && ((Entities.User)HttpContext.Current.Session["loggedUser"]).Id != 2)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (HttpContext.Current.Session["loggedUser"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "Login"}));
            }
        }
    }
}