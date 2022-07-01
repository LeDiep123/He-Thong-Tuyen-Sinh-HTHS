using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
//using He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Dao;
using Models.Dao;
using Models.Dto;
using Models.Entity;
using PagedList;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Controllers
{
    public class HoSoDuTuyenController : Controller
    {
        // GET: Admin/HoSoDuTuyen
        DiaChiDao dc = new DiaChiDao();
        NguyenVongDao de = new NguyenVongDao();
        HeThongTuyenSinhDDBcontext db = new HeThongTuyenSinhDDBcontext();
        HoSoDuTuyenDao dm = new HoSoDuTuyenDao();
        FileDao fAll = new FileDao();
        DoiTuongUuTienDao da = new DoiTuongUuTienDao();


      

        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {

            ViewBag.lstTruong = de.getAllTruong();
            ViewBag.lstTinh = dc.getAllTinh();
            ViewBag.lstDoiTuongUuTien = da.getAllDoiTuongUuTien();

            var listHocSinhDao = dm.ListAllPaging(search);
            var listHocSinhDto = new List<HocSinh_DTUT_Dto>();
            foreach (var hocsinhDao in listHocSinhDao)
            {
                var hocsinhDto = new HocSinh_DTUT_Dto()
                {
                    ID = hocsinhDao.ID,
                    TenHS = hocsinhDao.TenHS,
                    GioTinh = hocsinhDao.GioTinh,
                    TrangThai = hocsinhDao.TrangThai,
                    DanhSachDTUT = new List<DTUT_Dto>()
                };

                var listDTUTDao = dm.getDoiTuongUuTienByHSId(hocsinhDao.ID);               
                var listDTUTDto = new List<DTUT_Dto>();
                foreach (var DTUTDao in listDTUTDao)
                {
                    var dtutDto = new DTUT_Dto()
                    {
                        ID = DTUTDao.ID,
                        KieuDoiTuongUuTien = DTUTDao.KieuDoiTuongUuTien
                    };
                    listDTUTDto.Add(dtutDto);
                }
                hocsinhDto.DanhSachDTUT = listDTUTDto;

                listHocSinhDto.Add(hocsinhDto);
            }


            //gom những đối tượng ưu tiên vào 1 hàng
            var listData = dm.GetAllHocSinh_DTUT() ;
            var result = listData.GroupBy(s => s.IdDTUT, (key, group) => new BaoCaoSoLuongTheoDTUT_Dto()
            {
                ID = key,
                TenKieuDoiTuongUuTien = /*String.Join(", ",group.Select(s=>s.KieuDoiTuongUuTien)),*/ group.First().KieuDoiTuongUuTien,  
                //join(", ", item.DanhSachDTUT.Select(s => s.KieuDoiTuongUuTien)
                SoLuong = group.Count()
            }).ToList();

            ViewBag.ThongKe = result;


            //var hienThiHocSinh = listHocSinhDao.GroupBy(s => s.ID, (a, b) => new HocSinh_DTUT_Dto()
            //{
            //    ID = a,
            //    TenHS = b.First().TenHS,
            //    GioTinh = b.First().GioTinh,
            //    TrangThai = b.First().TrangThai,
            //    DanhSachDTUTS = String.Join(",", b.Select(s => s.KieuDoiTuongUuTien))


            //}).ToList();

            ViewBag.Search = search;

            return View(listHocSinhDto.ToPagedList(page, pageSize));
        }



        //Xóa nhiều bản ghi 1 lúc        
        public JsonResult DelAll(string dataString)
        {
            //kéo thư viện ra
            JavaScriptSerializer js = new JavaScriptSerializer();
            // convert string sang List<int>
            List<int> idArray = js.Deserialize<List<int>>(dataString);
            foreach (var item in idArray)
            {
                HocSinh idHocSinh = db.HocSinhs.FirstOrDefault(x => x.ID == item);

                idHocSinh.TrangThai = 10;
                db.SaveChanges();

            }
            return Json(new
            {
                status = true,

            }, JsonRequestBehavior.AllowGet);
        }

        //Xóa từng bản ghi
        public JsonResult Del(int id)
        {
            HocSinh item = db.HocSinhs.FirstOrDefault(x => x.ID == id);
            if (item != null)
            {
                item.TrangThai = 10;
                db.SaveChanges();
            }

            return Json(new
            {
                status = true,

                mess = "Đã xóa thành công bản ghi"
            }, JsonRequestBehavior.AllowGet);
        }


        //Xóa từng file theo Id truyền vào
        public JsonResult DelFile(int ID)
        {
            var IdFile = db.Files.FirstOrDefault(a => a.ID == ID);
            
                db.Files.Remove(IdFile);
                db.SaveChanges();
            
            
            return Json(new
            {
                status = true,

                mess = "Đã xóa thành công"
            }, JsonRequestBehavior.AllowGet);
        }
    


        //Sửa từng hồ sơ và xem hồ sơ
        public JsonResult Getdata(int id)
        {

            var item = dm.getDataByID(id);

            var itemFile = fAll.getAllFile(id);

            var idDTUT = fAll.getAllUT(id);


            return Json(new
            {
                status = true,
                data = item,
                itemFile = itemFile,
                idDTUT = idDTUT,
            }, JsonRequestBehavior.AllowGet);
        }

        //Duyệt nhiều hs 
        public JsonResult DuyetAll(string dataString)
        {
            //kéo thư viện ra
            JavaScriptSerializer js = new JavaScriptSerializer();
            // convert string sang List<int>
            List<int> idArray = js.Deserialize<List<int>>(dataString);
            foreach (var item in idArray)
            {
                HocSinh idHocSinh = db.HocSinhs.FirstOrDefault(x => x.ID == item);
                if (idHocSinh != null)
                {
                    idHocSinh.TrangThai = 3;
                    db.SaveChanges();
                }
            }
            return Json(new
            {
                status = true,


            }, JsonRequestBehavior.AllowGet);
        }

        //Duyệt từng hồ sơ
        public JsonResult Brower(int id)
        {
            HocSinh item = db.HocSinhs.FirstOrDefault(x => x.ID == id);
            if (item != null)
            {
                item.TrangThai = 3;
                db.SaveChanges();
            }
            return Json(new
            {
                status = true,


            }, JsonRequestBehavior.AllowGet);
        }



        //Xử lý từng hồ sơ trả lại
        [HttpPost]
        public JsonResult SaveBack(FormCollection f)
        {
            try
            {
                string NoiDung = f["NoiDung"] != null ? f["NoiDung"].Trim() : "";
                int ID = int.Parse(f["ID"].ToString());
                var hs = db.HocSinhs.Find(ID);
                hs.NoiDung = NoiDung;
                hs.TrangThai = 4;
                db.SaveChanges();

                return Json(new
                {
                    status = true,

                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    status = false,

                }, JsonRequestBehavior.AllowGet);
            }


        }

        //Xử lý nhiều hồ sơ trả lại 1 lúc
        [HttpPost]
        public JsonResult SaveBackAll(string dataId, string NoiDung)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            List<int> idArray = js.Deserialize<List<int>>(dataId);

            foreach (var item in idArray)
            {
                HocSinh idHocSinh = db.HocSinhs.Find(item);
                if (idHocSinh != null)
                {
                    idHocSinh.NoiDung = NoiDung;
                    idHocSinh.TrangThai = 4;
                    db.SaveChanges();
                }
            }
            return Json(new
            {
                status = true,

            }, JsonRequestBehavior.AllowGet);
        }
    }
}