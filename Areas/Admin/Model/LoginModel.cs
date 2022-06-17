using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Model
{
    public class LoginModel
    {
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage ="Mời nhập tài khoản")]
        public string UseName { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Nho tai khoan")]
        public bool RemerberMe { get; set; }
    }
}