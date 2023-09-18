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
    public class NhaSanXuatAdminController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Admin/NhaSanXuat
        
        public ActionResult Index()
        {
            return View(website2.Models.NhaSanXuatBUS.DanhSach());
        }

        // GET: Admin/NhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhaSanXuat model)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var check = db.NhaSanXuats.FirstOrDefault(m => m.TenNhaSanXuat == model.TenNhaSanXuat);
                if(check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NhaSanXuats.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Tên nhà sản xuất đã được sử dụng";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            return View(website2.Models.NhaSanXuatBUS.ChiTietNSX(id));
        }

        
        // POST: Admin/NhaSanXuat/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NhaSanXuat model)
        {
            if (ModelState.IsValid)
            {
                var UpdateModel = db.NhaSanXuats.Find(id);
                var check = db.NhaSanXuats.FirstOrDefault(m => m.TenNhaSanXuat == model.TenNhaSanXuat);
                if (check == null || check.TenNhaSanXuat == UpdateModel.TenNhaSanXuat)
                {
                    UpdateModel.TenNhaSanXuat = model.TenNhaSanXuat;
                    UpdateModel.TinhTrang = model.TinhTrang;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Tên nhà sản xuất đã được sử dụng";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        
        // GET: Admin/NhaSanXuat/Delete/5
        public ActionResult Delete(int id)
        {
            var DeleteModel = db.NhaSanXuats.Find(id);
            db.NhaSanXuats.Remove(DeleteModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        
    }
}
