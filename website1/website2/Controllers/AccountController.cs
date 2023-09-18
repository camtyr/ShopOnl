using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using website2.Models;

namespace website2.Controllers
{

    public class AccountController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account model)
        {
            if (ModelState.IsValid)
            {
                var check = db.Accounts.FirstOrDefault(m => m.UserName.Equals(model.UserName));
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(new Account
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                    });
                    db.KhachHangs.Add(new KhachHang
                    {
                        UserName = model.UserName,
                    });
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Error"] = "Tên đăng nhập đã được sử dụng";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var khSession = db.Accounts.SingleOrDefault(m => m.UserName.ToLower().Equals(UserName.ToLower()) && m.Password.Equals(Password));
                if (khSession != null)
                {
                    Session["user"] = khSession;
                    if (khSession.UserName == "admin")
                    {
                        return RedirectToAction("index", "HomeAdmin", new {area = "Admin"});
                    }    
                    
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    TempData["Error"] = "Tài khoản hoặc mật khẩu không đúng";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("user");

            return RedirectToAction("Login");
        }

    }
}