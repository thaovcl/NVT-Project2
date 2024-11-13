using System.Web.Mvc;

namespace K22CNT1_NguyenVanThao_2210900125.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "K22CNT1_NguyenVanThao_2210900125.Areas.Admin.Controllers" }
            );
        }
    }
}