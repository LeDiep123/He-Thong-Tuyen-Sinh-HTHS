using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Controllers
{
    public class TrangQuanLyController : Controller
    {
        // GET: Admin/TrangQuanLy
        public ActionResult Index()
        {
            var check = (UserLogin)Session["Remeber"];

            if(check == null)
            {
                return RedirectToAction("Index", "TrangLogin");
            }
            else
            {
                return View();
            }
            
        }
        
    }
}