using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.Dao;
using System.IO;
using System.Web.Script.Serialization;

namespace He_Thong_Tuyen_Sinh_HTHS.Controllers
{
    public class DK_du_tuyenController : Controller
    {
        // GET: DK_du_tuyen
        DoiTuongUuTienDao da = new DoiTuongUuTienDao();
        DiaChiDao dc = new DiaChiDao();
        NguyenVongDao de = new NguyenVongDao();
        HTTuyenSinhDBcontext db = new HTTuyenSinhDBcontext();

        public ActionResult Index()
        {
            ViewBag.lstTruong = de.getAllTruong();
            ViewBag.lstTinh = dc.getAllTinh();
            ViewBag.lstDoiTuongUuTien = da.getAllDoiTuongUuTien();
            return View();
        }

        public JsonResult ChangeTinh(int id)
        {
            List<DiaChi> lstChil = dc.getCon(id);
            return Json(new
            {
                status = true,
                data = lstChil
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeHuyen(int id)
        {
            List<DiaChi> lstChil = dc.getCon(id);
            return Json(new
            {
                status = true,
                data = lstChil
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeTruong(int id)
        {
            List<Truong> lstChil = de.getListTruong(id);
            return Json(new
            {
                status = true,
                data = lstChil
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveCreate(FormCollection c)
        {
            string mess = string.Empty;
            string TenHS = c["HoTen"] != null ? c["HoTen"].Trim() : "";
            string Ngaysinh = c["NgaySinhHs"] != null ? c["NgaySinhHs"].Trim() : "";
            string DanToc = c["DanToc"] != null ? c["DanToc"].Trim() : "";
            int IDHuyenThT = int.Parse(c["HuyenThuongTru"].ToString());
            string Email = c["Email"] != null ? c["Email"].Trim() : "";
            string SoNhaThuongTru = c["SoNhaThuongTru"] != null ? c["SoNhaThuongTru"].Trim() : "";
            string TenMe = c["HoTenMe"] != null ? c["HoTenMe"].Trim() : "";
            string NgheNghiepMe = c["NgheNghiepMe"] != null ? c["NgheNghiepMe"].Trim() : "";
            string SDTMe = c["sdtMe"] != null ? c["sdtMe"].Trim() : "";
            string TenBo = c["HoTenBo"] != null ? c["HoTenBo"].Trim() : "";
            string NgheNghiepBo = c["NgheNghiepBo"] != null ? c["NgheNghiepBo"].Trim() : "";
            string SDTBo = c["sdtBo"] != null ? c["sdtBo"].Trim().Replace(" ", "") : "";
            string TenNGH = c["TenNguoiGiamHo"] != null ? c["TenNguoiGiamHo"].Trim() : "";
            string SDTNGH = c["sdtGiamHo"] != null ? c["sdtGiamHo"].Trim() : "";
            string NgheNghiepNGH = c["NgheNghiepGiamHo"] != null ? c["NgheNghiepGiamHo"].Trim() : "";
            int IDTinhThT = int.Parse(c["TinhThuongTru"].ToString());
            int IDXaThT = int.Parse(c["XaThuongTru"].ToString());
            int IDTinhTT = int.Parse(c["TinhTamTru"].ToString());
            int IDHuyenTT = int.Parse(c["HuyenTamTru"].ToString());
            int IDXaTT = int.Parse(c["XaTamTru"].ToString());
            string SoNhaTamTru = c["SoNhaTamTru"] != null ? c["SoNhaTamTru"].Trim() : "";
            int NguyenVong1 = int.Parse(c["NguyenVong1"].ToString());
            int NguyenVong2 = int.Parse(c["NguyenVong2"].ToString());
            string arrDTUT = c["UT"].ToString();
            //int DTUT = int.Parse(c["DTUT"].ToString());
            
            int ID = int.Parse(c["ID"].ToString());
            if (ID == 0)
            {
                HocSinh hs = new HocSinh();

                if (c["GioiTinh"] == "1")
                {
                    hs.GioTinh = true;
                }
                else
                {
                    hs.GioTinh = false;
                }
                hs.TenHS = TenHS;
                hs.NgaySinh = Ngaysinh;
                hs.DanToc = DanToc;
                hs.IDHuyenThT = IDHuyenThT;
                hs.Email = Email;
                hs.SoNhaThuongTru = SoNhaThuongTru;
                hs.TenMe = TenMe;
                hs.NgheNghiepMe = NgheNghiepMe;
                hs.SDTMe = SDTMe;
                hs.TenBo = TenBo;
                hs.NgheNghiepBo = NgheNghiepBo;
                hs.SDTBo = SDTBo;
                hs.TenNGH = TenNGH;
                hs.SDTNGH = SDTNGH;
                hs.NgheNghiepNGH = NgheNghiepNGH;
                hs.IDTinhThT = IDTinhThT;
                hs.IDXaThT = IDXaThT;
                hs.IDTinhTT = IDTinhTT;
                hs.IDHuyenTT = IDHuyenTT;
                hs.IDXaTT = IDXaTT;
                hs.SoNhaTamTru = SoNhaTamTru;
                hs.NguyenVong1 = NguyenVong1;
                hs.NguyenVong2 = NguyenVong2;
                //hs.DTUT = DTUT;
                hs.TrangThai = 1;
                db.HocSinhs.Add(hs);
                db.SaveChanges();
                var idHs = hs.ID;

                // lưu dữ liệu vào bảng HocSinh_TKDTUT
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> idUT = js.Deserialize<List<int>>(arrDTUT);

                foreach (var items in idUT)
                {
                    var addDTUT = new HocSinh_TKDTUT();
                    addDTUT.ID_HocSinh = idHs;
                    addDTUT.ID_TenKieuDoiTuongUT = items;
                    db.HocSinh_TKDTUT.Add(addDTUT);
                    db.SaveChanges();
                                  
                }

                //lưu file vào bảng
                HttpFileCollectionBase files = Request.Files;               
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fname = file.FileName;
                    string path = Server.MapPath("~/Uploads/File");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fullPath = Path.Combine(path, fname);
                    file.SaveAs(fullPath);
                    var ffiless = new DocumentFile();
                    ffiless.TrangThai = 1;
                    ffiless.MaFile = "a1";
                    ffiless.ID_HocSinh = idHs;
                    ffiless.TenFile = fname;
                    db.Files.Add(ffiless);
                    db.SaveChanges();
                }
                               
                mess = "Thêm mới thành công";
            }
            else
            {

                var hs = db.HocSinhs.Find(ID);
                if (c["GioiTinh"] == "1")
                {
                    hs.GioTinh = true;
                }
                else
                {
                    hs.GioTinh = false;
                }
                hs.TenHS = TenHS;
                hs.NgaySinh = Ngaysinh;
                hs.DanToc = DanToc;
                hs.IDHuyenThT = IDHuyenThT;
                hs.Email = Email;
                hs.SoNhaThuongTru = SoNhaThuongTru;
                hs.TenMe = TenMe;
                hs.NgheNghiepMe = NgheNghiepMe;
                hs.SDTMe = SDTMe;
                hs.TenBo = TenBo;
                hs.NgheNghiepBo = NgheNghiepBo;
                hs.SDTBo = SDTBo;
                hs.TenNGH = TenNGH;
                hs.SDTNGH = SDTNGH;
                hs.NgheNghiepNGH = NgheNghiepNGH;
                hs.IDTinhThT = IDTinhThT;
                hs.IDXaThT = IDXaThT;
                hs.IDTinhTT = IDTinhTT;
                hs.IDHuyenTT = IDHuyenTT;
                hs.IDXaTT = IDXaTT;
                hs.SoNhaTamTru = SoNhaTamTru;
                hs.NguyenVong1 = NguyenVong1;
                hs.NguyenVong2 = NguyenVong2;
                //hs.DTUT = DTUT;
                hs.TrangThai = 1;
                db.SaveChanges();
                var idHS = hs.ID;
                
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fname = file.FileName;
                    string path = Server.MapPath("~/Uploads/File");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fullPath = Path.Combine(path, fname);
                    file.SaveAs(fullPath);
                    var ffiless = new DocumentFile();
                    ffiless.TrangThai = 1;
                    ffiless.MaFile = "a1";
                    ffiless.ID_HocSinh = idHS;
                    ffiless.TenFile = fname;

                    db.Files.Add(ffiless);
                    db.SaveChanges();
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> idDTUT = js.Deserialize<List<int>>(arrDTUT);

                foreach (var itemss in idDTUT)
                {

                    var addDTUT = new HocSinh_TKDTUT();
                    addDTUT.ID_HocSinh = idHS;
                    addDTUT.ID_TenKieuDoiTuongUT = itemss;
                    db.HocSinh_TKDTUT.Add(addDTUT);
                    db.SaveChanges();


                }

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //List<int> idUT = js.Deserialize<List<int>>();

                mess = "Sửa thành công";
            }

            return Json(new
            {
                status = true,
                mess = mess
            }, JsonRequestBehavior.AllowGet);
        }

    }
}