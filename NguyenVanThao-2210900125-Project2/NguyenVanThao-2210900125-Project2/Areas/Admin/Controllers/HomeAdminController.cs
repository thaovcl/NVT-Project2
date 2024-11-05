using NguyenVanThao_2210900125_Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace NguyenVanThao_2210900125_Project2.Areas.Admin.Controllers
{
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            if(Session["user"]==null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View(); 
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            //check db
            NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();
            var nhanVien = db.NHAN_VIEN.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            //check code
            if (nhanVien != null)
            {   
                Session["user"] = nhanVien;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            // xóa session
            Session.Remove("user");
            //xóa session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("DangNhap");
        }
    }
}