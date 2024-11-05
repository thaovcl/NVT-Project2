using NguyenVanThao_2210900125_Project2.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NguyenVanThao_2210900125_Project2.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public int idChucNang { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Kiểm tra session: đã đăng nhập => cho thực hiện filter 
            NHAN_VIEN nvSession = (NHAN_VIEN)HttpContext.Current.Session["user"];
            if (nvSession != null)
            {
                // Kiểm tra quyền: có quyền thì => cho thực hiện filter
                using (var db = new NguyenVanThao_K22CNT1_Project2Entities1())
                {
                    var hasPermission = db.PHAN_QUYEN.Any(m => m.idNhanVien == nvSession.ID && m.idChucNang == idChucNang);

                    if (!hasPermission)
                    {
                        // Nếu không có quyền, redirect đến trang báo lỗi
                        var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                        new
                        {
                            controller = "BAO_LOI",
                            action = "KhongCoQuyen",
                            area = "Admin",
                            returnUrl = returnUrl
                        }));
                    }
                }
                return; // Nếu đã có quyền, tiếp tục xử lý yêu cầu
            }
            else
            {
                // Nếu chưa đăng nhập, redirect đến trang đăng nhập
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new
                {
                    controller = "HomeAdmin",
                    action = "DangNhap",
                    area = "Admin",
                    returnUrl = returnUrl
                }));
            }
        }
    }
}
