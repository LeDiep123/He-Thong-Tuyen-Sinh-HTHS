using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Controllers
{
    public class HoSoXetTuyenController : Controller
    {
        DoiTuongUuTienDao da = new DoiTuongUuTienDao();
        DiaChiDao dc = new DiaChiDao();
        NguyenVongDao de = new NguyenVongDao();
        HTTuyenSinhDBcontext db = new HTTuyenSinhDBcontext();
        HoSoDuTuyenDao dm = new HoSoDuTuyenDao();
        // GET: Admin/HoSoXetTuyen
        public ActionResult Index(string searchss)
        {
            if (searchss == null)
            {
                //ViewBag.lst = dm.GetAll();
                ViewBag.lstTruong = de.getAllTruong();
                ViewBag.lstTinh = dc.getAllTinh();
                ViewBag.lstDoiTuongUuTien = da.getAllDoiTuongUuTien();
                ViewBag.lssxt = dm.GetXT();
                return View();
            }
            else
            {
                ViewBag.lssxt = dm.getSeaXT( searchss);
                ViewBag.lstTruong = de.getAllTruong();
                ViewBag.lstTinh = dc.getAllTinh();
                ViewBag.lstDoiTuongUuTien = da.getAllDoiTuongUuTien();
                return View();
            }
           
        }
    }
}