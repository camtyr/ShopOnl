using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.App_Start;

namespace website2.Controllers
{
    [UserAuthorize]
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult Index(int id)
        {
            return View(website2.Models.LoaiSanPhamBUS.DanhSachSP_TinhTrang(id));
        }
    }
}