using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website2.App_Start;

namespace website2.Controllers
{
    [UserAuthorize]
    public class ProducerController : Controller
    {
        
        public ActionResult Index(int id)
        {
            return View(website2.Models.NhaSanXuatBUS.DanhSachSP_TinhTrang(id));
        }
    }
}