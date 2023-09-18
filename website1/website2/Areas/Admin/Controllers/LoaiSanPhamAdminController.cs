using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.Models;
using website2.App_Start;

namespace website2.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class LoaiSanPhamAdminController : Controller
    {
        
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Admin/LoaiSanPham
        
        public ActionResult Index()
        {
            return View(website2.Models.LoaiSanPhamBUS.DanhSach());
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiSanPham model)
        {
            if (ModelState.IsValid)
            {
                var check = db.LoaiSanPhams.SingleOrDefault(m => m.TenLoaiSanPham == model.TenLoaiSanPham);
                if(check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.LoaiSanPhams.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("index");

                }
                else
                {
                    TempData["error"] = "Tên loại sản phẩm đã được sử dụng";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        
        public ActionResult Edit(int id)
        {
            return View(website2.Models.LoaiSanPhamBUS.ChiTietLSP(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoaiSanPham model)
        {
            if (ModelState.IsValid)
            {
                var UpdateModel = db.LoaiSanPhams.Find(id);
                var check = db.LoaiSanPhams.FirstOrDefault(m => m.TenLoaiSanPham == model.TenLoaiSanPham);
                if (check == null || check.TenLoaiSanPham == UpdateModel.TenLoaiSanPham)
                {
                    UpdateModel.TenLoaiSanPham = model.TenLoaiSanPham;
                    UpdateModel.TinhTrang = model.TinhTrang;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Tên loại sản phẩm đã được sử dụng";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            var DeleteModel = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(DeleteModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
