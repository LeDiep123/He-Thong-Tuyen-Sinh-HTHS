using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.Entity;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Controllers
{
    public class HoSoTraLaiController : Controller
    {
        DoiTuongUuTienDao da = new DoiTuongUuTienDao();
        DiaChiDao dc = new DiaChiDao();
        NguyenVongDao de = new NguyenVongDao();
        HeThongTuyenSinhDDBcontext db = new HeThongTuyenSinhDDBcontext();
        HoSoDuTuyenDao dm = new HoSoDuTuyenDao();
        // GET: Admin/HoSoTraLai
        public ActionResult Index()
        {
            
                ViewBag.lstTruong = de.getAllTruong();
                ViewBag.lstTinh = dc.getAllTinh();
                ViewBag.lstDoiTuongUuTien = da.getAllDoiTuongUuTien();               
                ViewBag.lsstl = dm.GetTL();

                return View();
           
           
        }
    }
}