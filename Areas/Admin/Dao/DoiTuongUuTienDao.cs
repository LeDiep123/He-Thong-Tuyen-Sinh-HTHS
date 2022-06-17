//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Models.EF;

//namespace Models.Dao
//{
   
//    public class DoiTuongUuTienDao
//    {
//        HeThongTuyenSinhDbcontext db = new HeThongTuyenSinhDbcontext();

//        public List<TenKieuDoiTuongUuTien> getAllDoiTuongUuTien()
//        {
//            List<TenKieuDoiTuongUuTien> item = new List<TenKieuDoiTuongUuTien>();
//            item = db.TenKieuDoiTuongUuTiens.Where(x => x.TrangThai == 2).ToList();
//            return item;
//        }
        

//        public List<HocSinh_TKDTUT> getAllUT(int ID)
//        {
//            return db.HocSinh_TKDTUT.Where(x => x.ID_HocSinh == ID).ToList();
//        }

//    }
//}
