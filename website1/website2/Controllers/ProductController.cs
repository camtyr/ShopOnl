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
    public class ProductController : Controller
    {
        QLBHEntities2 db = new QLBHEntities2();
        // GET: Product
        public ActionResult Index()
        {
            
            return View(website2.Models.SanPhamBUS.DanhSach_TinhTrang());
        }


        public ActionResult Details(int id)
        {
            return View(website2.Models.SanPhamBUS.ChiTietSP(id));
        }

        
    }
}