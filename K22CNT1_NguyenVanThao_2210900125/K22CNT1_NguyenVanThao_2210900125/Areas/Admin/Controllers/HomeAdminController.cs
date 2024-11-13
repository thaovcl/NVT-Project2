using K22CNT1_NguyenVanThao_2210900125.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace K22CNT1_NguyenVanThao_2210900125.Areas.Admin.Controllers
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
            // Kiểm tra xem nhân viên đã đăng nhập chưa
            var user = Session["user"];
            if (user == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng về trang đăng nhập
                return RedirectToAction("Login", "NVT_KHACH_HANG", new { area = "" });
            }

            return View();
        }
        
        public ActionResult DangXuat()
        {
            // xóa session
            Session.Remove("user");
            //xóa session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "NVT_KHACH_HANG", new { area = "" });
        }
    }
}