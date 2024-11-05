using System.Web;
using System.Web.Mvc;

namespace NguyenVanThao_2210900125_Project2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
