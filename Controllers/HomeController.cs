using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace He_Thong_Tuyen_Sinh_HTHS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var db = new HeThongTuyenSinh();
            //db.DiaChis.Add(new DiaChi() { TenDiaChi = "TenDiaChi", MaDiaChi = 878});
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}