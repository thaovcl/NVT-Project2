using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using K22CNT1_NguyenVanThao_2210900125.Bussiness;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Controllers
{
    public class NVTCartController : Controller
    {
        private const string NVTCartSessionKey = "NVTCartSessionKey";
        NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        private NVT_TourCart GetCart()
        {
            var cart = Session[NVTCartSessionKey] as NVT_TourCart;
            if(cart == null)
            {
                cart = new NVT_TourCart();
                Session[NVTCartSessionKey] = cart;
            }
            return cart;
        }
        //Add to cart: Thêm 1 tour vào giỏ hàng
        public ActionResult AddToCart(int id, string TenTour, string HinhAnh, int SoNguoiMua, float DonGiaMua)
        {
            // Kiểm tra xem khách hàng đã đăng nhập chưa
            if (Session["KhachHang"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "NVT_KHACH_HANG");
            }

            var cart = GetCart();
            var item = new NVTCartItem
            {
                ID = id,
                TenTour = TenTour,
                HinhAnh = HinhAnh,
                SoNguoiMua = SoNguoiMua,
                DonGiaMua = DonGiaMua,
                ThanhTien = SoNguoiMua * DonGiaMua
            };

            cart.AddToCart(item);
            return RedirectToAction("Index");
        }

        // GET: NVTCart - Hiển thị các sản phẩm trong giỏ hàng
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart.Items);
        }

        //Thông tin thanh toán
        public ActionResult ThongTinThanhToan()
        {
            // Kiểm tra xem khách hàng đã đăng nhập chưa
            if (Session["KhachHang"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "NVT_KHACH_HANG");
            }

            var cart = GetCart();
            ViewBag.TongTriGia = cart.GetTongThanhTien();
            DateTime dt = DateTime.Now;
            var Ma_hoa_don = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            ViewBag.Ma_hoa_don = Ma_hoa_don;
            return View(cart.Items);
        }


        //Cập nhật và thanh toán
        public ActionResult ThanhToan(FormCollection form)
        {
            // Kiểm tra xem khách hàng đã đăng nhập chưa
            if (Session["KhachHang"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "NVT_KHACH_HANG");
            }

            var cart = GetCart();

            // Lấy các thông tin trên form để cập nhật bảng hóa đơn
            var Ho_ten = form["Ho_ten"];
            var Email = form["Email"];
            var Dien_thoai = form["Dien_thoai"];
            var Dia_chi = form["Dia_chi"];

            // Thông tin đơn hàng
            DateTime dt = DateTime.Now;
            var Ma_hoa_don = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            var Tong_tien = cart.GetTongThanhTien();

            // Thêm mới vào bảng hóa đơn
            var hoaDon = new HOA_DON();
            hoaDon.Ma_hoa_don = Ma_hoa_don;
            hoaDon.Ngay_thanh_toan = dt;
            hoaDon.Tong_tien = Tong_tien;
            hoaDon.Ho_ten = Ho_ten;
            hoaDon.Email = Email;
            hoaDon.Dien_thoai = Dien_thoai;
            hoaDon.Dia_chi = Dia_chi;

            db.HOA_DON.Add(hoaDon);
            db.SaveChanges();

            // Lấy ID hóa đơn vừa thêm
            int hoaDonId = db.HOA_DON.Max(x => x.ID);

            // Thêm vào chi tiết hóa đơn
            foreach (var item in cart.Items)
            {
                CT_HOA_DON ct = new CT_HOA_DON();
                ct.HoaDonID = hoaDonId;
                ct.TourID = item.ID;
                ct.DonGia = item.ThanhTien;

                db.CT_HOA_DON.Add(ct);
                db.SaveChanges();
            }

            return RedirectToAction("CamOn");
        }

        public ActionResult CamOn()
        {
            return View();
        }

        //cập nhật giỏ hàng
        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["ID"].Split(',');
            var qtys = form["SoNguoiMua"].Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                int qty = int.Parse(qtys[i]);
                cart.UpdateFromCart(id, qty);
            }
            return RedirectToAction("Index");
        }

        //Cap nhat item in cart
        public ActionResult UpdateItemCart( int id, int qty)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id, qty); 
            return RedirectToAction("Index");
        }

        //Xóa sản phẩm trong giỏ hàng
        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveCartItem(id);
            return RedirectToAction("Index");
        }

    }
}