using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.Models;
using website2.App_Start;

namespace website2.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class SanPhamAdminController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Admin/SanPham
        
        public ActionResult Index()
        {
            return View(website2.Models.SanPhamBUS.DanhSach());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SanPham model)
        {
            if (ModelState.IsValid)
            {
                var check = db.SanPhams.SingleOrDefault(m => m.TenSanPham == model.TenSanPham);
                if(check == null)
                {
                    model.SoLuongDaBan = 0;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SanPhams.Add(model);
                
                    var hpf = HttpContext.Request.Files[0];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.HinhChinh = model.TenSanPham + ".png";

                    }
                    hpf = HttpContext.Request.Files[1];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh1 = model.TenSanPham + "_1.png";
                    }
                    hpf = HttpContext.Request.Files[2];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh2 = model.TenSanPham + "_2.png";
                    }
                    hpf = HttpContext.Request.Files[3];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh3 = model.TenSanPham + "_3.png";
                    }
                    hpf = HttpContext.Request.Files[4];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh4 = model.TenSanPham + "_4.png";
                    }

                    db.SaveChanges();

                    return RedirectToAction("index");
                }
                else
                {
                    TempData["Error"] = "Tên sản phẩm đã tồn tại";
                    ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
                    ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
                    return View(model);
                }
                
            }
            else
            {
                ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
                ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
                return View(model);
            }
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham", SanPhamBUS.ChiTietSP(id).MaLoaiSanPham);
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat", SanPhamBUS.ChiTietSP(id).MaNhaSanXuat);
            return View(website2.Models.SanPhamBUS.ChiTietSP(id));
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, SanPham model)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var check = db.SanPhams.SingleOrDefault(m => m.TenSanPham == model.TenSanPham);
                var UpdateModel = db.SanPhams.Find(id);
                if(check == null || check.TenSanPham == UpdateModel.TenSanPham)
                {
                    UpdateModel.TenSanPham = model.TenSanPham;
                    UpdateModel.MaLoaiSanPham = model.MaLoaiSanPham;
                    UpdateModel.MaNhaSanXuat = model.MaNhaSanXuat;
                    UpdateModel.CauHinh = model.CauHinh;
                    UpdateModel.TinhTrang = model.TinhTrang;
                    UpdateModel.Gia = model.Gia;

                    var hpf = HttpContext.Request.Files[0];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.HinhChinh = model.TenSanPham + ".png";
                        UpdateModel.HinhChinh = model.HinhChinh;
                    }
                    hpf = HttpContext.Request.Files[1];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh1 = model.TenSanPham + "_1.png";
                        
                        UpdateModel.Hinh1 = model.Hinh1;
                    }
                    hpf = HttpContext.Request.Files[2];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh2 = model.TenSanPham + "_2.png";
                        UpdateModel.Hinh2 = model.Hinh2;
                    }
                    hpf = HttpContext.Request.Files[3];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh3 = model.TenSanPham + "_3.png";
                        UpdateModel.Hinh3 = model.Hinh3;
                    }
                    hpf = HttpContext.Request.Files[4];
                    if (hpf.ContentLength > 0)
                    {
                        string FileName = model.TenSanPham;
                        string FullPathWithFileName = "~/assets/img/" + FileName + ".png";
                        hpf.SaveAs(Server.MapPath(FullPathWithFileName));
                        model.Hinh4 = model.TenSanPham + "_4.png";
                        UpdateModel.Hinh4 = model.Hinh4;
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Tên sản phẩm đã tồn tại";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            var DeleteModel = db.SanPhams.Find(id);
            db.SanPhams.Remove(DeleteModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
