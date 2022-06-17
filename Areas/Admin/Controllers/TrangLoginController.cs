using He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Model;
using He_Thong_Tuyen_Sinh_HTHS.Common;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace He_Thong_Tuyen_Sinh_HTHS.Areas.Admin.Controllers
{
    public class TrangLoginController : Controller
    {
        // GET: Admin/TrangQuanLy
        public ActionResult Index()
        {
            var check = (UserLogin)Session["Remeber"];           
            if (check == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "TrangQuanLy");
            }

        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
             {
                var dao = new UserDao();
                var result = dao.Login(model.UseName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetById(model.UseName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add("Remeber", userSession);

                    return RedirectToAction("Index", "TrangQuanLy");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu bị sai");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "TrangLogin");
        }
    }


}