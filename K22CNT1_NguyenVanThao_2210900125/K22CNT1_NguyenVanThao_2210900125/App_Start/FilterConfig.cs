using System.Web;
using System.Web.Mvc;

namespace K22CNT1_NguyenVanThao_2210900125
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
