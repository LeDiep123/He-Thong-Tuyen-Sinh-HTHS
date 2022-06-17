//using Models.EF;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PagedList;
//using He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Model;
//using System.Web.Mvc;

//namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Dao
//{
//    public class HoSoDuTuyenDao_Admin
//    {
//        HTTuyenSinhDBcontext db = null;

//        public HoSoDuTuyenDao_Admin()
//        {
//            db = new HTTuyenSinhDBcontext();
//        }

//        //Show ra list hs duyệt trang thai 3
//        public List<HocSinh> GetXT()
//        {
//            var lssAll = db.HocSinhs.Where(x => x.TrangThai == 3).ToList();
//            return lssAll;
//        }

//        //Show ra list hs tra lai trang thai 4
//        public List<HocSinh> GetTL()
//        {
//            var lsstl = db.HocSinhs.Where(x => x.TrangThai == 4).ToList();
//            return lsstl;
//        }

//        //tìm kiếm hoặc list ra ds hs trạng thái bằng 1
//        public IEnumerable<HocSinh_DTUT> ListAllPaging(int page, int pageSize, string search)
//        {
//            var lstHsDTUT = new List<HocSinh_DTUT>();
//            if (search == null)
//            {
//                string queryString = $@"select HocSinh.*,TenKieuDoiTuongUuTien.KieuDoiTuongUuTien
//                            from HocSinh_TKDTUT
//                            inner join HocSinh on HocSinh.ID=HocSinh_TKDTUT.ID_HocSinh
//                            inner join TenKieuDoiTuongUuTien on TenKieuDoiTuongUuTien.ID=HocSinh_TKDTUT.ID_TenKieuDoiTuongUT
//                ";
//                lstHsDTUT = db.Database.SqlQuery<HocSinh_DTUT>(queryString).ToList();
//                var pageLst = lstHsDTUT.Where(x => x.TrangThai == 1).OrderBy(x => x.ID).ToPagedList(page, pageSize);

//                return pageLst;

//            }
//            else
//            {
//                var pageLst = lstHsDTUT.Where(x => x.TrangThai == 1 && x.TenHS.Contains(search)).OrderBy(x => x.ID).ToPagedList(page, pageSize);
//                return pageLst;
//            }
//        }

//        //Sửa từng hồ sơ và xem hồ sơ
//        public HocSinh getDataByID(int id)
//        {
//            return db.HocSinhs.FirstOrDefault(x => x.ID == id);
//        }



//        //tìm kiếm hs xét tuyển
//        public List<HocSinh> getSeaXT(string searchss)
//        {
//            var lstXT = db.HocSinhs.Where(x => x.TrangThai == 3 && x.TenHS.Contains(searchss)).ToList();
//            return lstXT;
//        }


//    }
//}
