using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.Models;
using website2.App_Start;

namespace website2.Controllers
{
    [UserAuthorize]
    public class GioHangController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: GioHang
        public ActionResult Index()
        {
            Account accSession = (Account)Session["user"];
            var khSession = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
            ViewBag.TongTien = website2.Models.GioHangBUS.TongTien(khSession.ID);
            return View(website2.Models.GioHangBUS.DanhSach(khSession.ID));
        }

        [HttpPost]
        public ActionResult Them(int MaSanPham, string TenSanPham, decimal Gia, int SoLuong)
        {
            
                Account accSession = (Account)Session["user"];
                var khSession = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
                GioHangBUS.Them(MaSanPham, TenSanPham, Gia, SoLuong, khSession.ID);
                return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult CapNhat(int MaSanPham, string TenSanPham, decimal Gia, int SoLuong)
        {
            Account accSession = (Account)Session["user"];
            var khSession = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
            
            GioHangBUS.CapNhat(MaSanPham, TenSanPham, Gia, SoLuong, khSession.ID);
            return RedirectToAction("Index");
        }

        public ActionResult Xoa(int id)
        {
             GioHangBUS.Xoa(id);
            return RedirectToAction("index");
        }

        public ActionResult CheckOut(FormCollection form)
        {

            Account accSession = (Account)Session["user"];
            var khSession = db.KhachHangs.SingleOrDefault(m => m.UserName == accSession.UserName);
            var gh = GioHangBUS.DanhSach(khSession.ID);
            if (gh.Count() > 0)
            {
                DonHang dh = new DonHang();
                dh.NgayTao = DateTime.Now;
                dh.DiaChi = form["Delivery"];
                dh.MaTaiKhoan = khSession.ID;
                db.DonHangs.Add(dh);
                db.SaveChanges();

                foreach (var item in gh)
                {
                    ChiTietDonHang ctgh = new ChiTietDonHang();
                    ctgh.IDDonHang = dh.IDDH;
                    ctgh.MaSanPham = item.MaSanPham;
                    ctgh.SoLuong = item.SoLuong;
                    db.ChiTietDonHangs.Add(ctgh);
                    GioHangBUS.Xoa(item.IDGH);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}