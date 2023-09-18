using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.Helper;
using website2.Models;
using website2.App_Start;

namespace website2.Controllers
{
    [UserAuthorize]
    public class HomeController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Home
        public ActionResult index()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult ThongTinTK()
        {
            Account accSession = (Account)Session["user"];
            KhachHang khSession = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
            return View(khSession);
        }

        public ActionResult CapNhatThongTinTK()
        {
            Account accSession = (Account)Session["user"];
            KhachHang KhachHangCanSua = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
            return View(KhachHangCanSua);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatThongTinTK(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                Account accSession = (Account)Session["user"];
                var UpdateModel = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
                UpdateModel.TenKhachHang = model.TenKhachHang;
                UpdateModel.DiaChi = model.DiaChi;
                UpdateModel.SoDienThoai = model.SoDienThoai;
                UpdateModel.Email = model.Email;
                db.SaveChanges();
                return RedirectToAction("ThongTinTK");
            }
            return View(model); 
            
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel ChPass)
        {
            if (ModelState.IsValid)
            {
                Account khSession = (Account)Session["user"];
                QLBHEntities2 db = new QLBHEntities2();
                var UpdatePassword = db.Accounts.Find(khSession.UserName);
                if (khSession.Password == ChPass.CurrentPassword)
                {
                    UpdatePassword.Password = ChPass.ConfirmPassword;
                    db.SaveChanges();
                    return RedirectToAction("Logout", "Account");
                }
                else
                {
                    TempData["Error"] = "Sai mật khẩu";
                    return View();
                }
            }
            return View();
        }
    }
}

