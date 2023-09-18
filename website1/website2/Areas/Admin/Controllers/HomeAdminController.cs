using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Security;
using website2.Models;
using website2.App_Start;

namespace website2.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeAdminController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
      
        public ActionResult Logout()
        {
            Session.Remove("user");

            return RedirectToAction("Login", "Account", new {area = ""});
        }
    }
}