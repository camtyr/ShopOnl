using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using website2.Models;

namespace website2.App_Start
{
    public class AdminAuthorize: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            
            
            Account admcheck = (Account)HttpContext.Current.Session["user"];
            if (admcheck != null)
            {
                if(admcheck.UserName == "admin") return;
                
                else
                {
                    //var returnUrl = filterContext.RequestContext.HttpContext.Request.Url;
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(
                        new
                        {
                            controller = "Account",
                            action = "login",
                            area = "",
                            //returnUrl = returnUrl.ToString(),
                        })) ;
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "login",
                        area = "",
                    }));
            }

        }
    }
}