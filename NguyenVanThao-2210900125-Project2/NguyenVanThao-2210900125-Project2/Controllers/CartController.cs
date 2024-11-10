using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenVanThao_2210900125_Project2.Models;

namespace NguyenVanThao_2210900125_Project2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        NguyenVanThao_K22CNT1_Project2Entities1 objWebsiteBanHangEntities = new NguyenVanThao_K22CNT1_Project2Entities1();
        // GET: Cart
        public ActionResult Index()
        {
            return View((List<Cart>)Session["cart"]);
        }

        public ActionResult AddToCart(int id, int quantity)
        {
            return View();
        }
    }
}