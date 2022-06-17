//using Models.Dao;
//using Models.EF;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Dao
//{
//    public class DoiTuongUuTien
//    {
//        HTTuyenSinhDBcontext db = new HTTuyenSinhDBcontext();

//        public List<TenKieuDoiTuongUuTien> getAllDoiTuongUuTien()
//        {
//            List<TenKieuDoiTuongUuTien> item = new List<TenKieuDoiTuongUuTien>();
//            item = db.TenKieuDoiTuongUuTiens.Where(x => x.TrangThai == 2).ToList();
//            return item;
//        }


//        //public List<HocSinh_DTUT> getAllUT(int ID)
//        //{
//        //    return;
//        //}

//    }
//}