using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1_NguyenVanThao_2210900125.Models;
using K22CNT1_NguyenVanThao_2210900125.ViewModel;

namespace K22CNT1_NguyenVanThao_2210900125.Controllers
{
    public class NVT_KHACH_HANGController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();
        // GET: NVT_KHACH_HANG

        public ActionResult OrderHistory()
        {
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Login");
            }

            // Lấy thông tin khách hàng từ session
            var khachHang = (KHACH_HANG)Session["KhachHang"];

            // Lấy danh sách các hóa đơn của khách hàng
            var hoaDons = db.HOA_DON.Where(h => h.Email == khachHang.Email).ToList();

            // Tạo danh sách các ViewModel chứa thông tin hóa đơn và chi tiết hóa đơn
            var orderHistoryList = new List<OrderHistoryViewModel>();

            foreach (var hoaDon in hoaDons)
            {
                var chiTietHoaDon = db.CT_HOA_DON.Where(ct => ct.HoaDonID == hoaDon.ID).ToList();
                var orderHistoryViewModel = new OrderHistoryViewModel
                {
                    HoaDon = hoaDon,
                    ChiTietHoaDon = chiTietHoaDon
                };

                orderHistoryList.Add(orderHistoryViewModel);
            }

            return View(orderHistoryList);
        }


        // Phương thức xóa đơn hàng
        public ActionResult DeleteOrder(int id)
        {
            // Tìm hóa đơn theo ID
            var hoaDon = db.HOA_DON.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound("Không tìm thấy hóa đơn cần xóa.");
            }

            // Xóa tất cả chi tiết hóa đơn liên quan
            var chiTietHoaDon = db.CT_HOA_DON.Where(ct => ct.HoaDonID == hoaDon.ID).ToList();
            if (chiTietHoaDon.Any())
            {
                db.CT_HOA_DON.RemoveRange(chiTietHoaDon);
            }

            // Xóa hóa đơn
            db.HOA_DON.Remove(hoaDon);
            db.SaveChanges();

            // Quay lại trang lịch sử đơn hàng sau khi xóa
            return RedirectToAction("OrderHistory");
        }

        // Phương thức xem chi tiết đơn hàng
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            // Kiểm tra nếu khách hàng đã đăng nhập
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Login", "KHACH_HANG"); // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
            }

            // Lấy hóa đơn theo id
            var hoaDon = db.HOA_DON.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound("Không tìm thấy hóa đơn này.");
            }

            // Lấy chi tiết hóa đơn
            var chiTietHoaDon = (from ct in db.CT_HOA_DON
                                 join sp in db.TOURs on ct.TourID equals sp.ID
                                 where ct.HoaDonID == id  // Lọc theo HoaDonID, không phải TourID
                                 select new DH_ChiTiet
                                 {
                                     ID = ct.ID,
                                     TenTour = sp.Ten_tour,
                                     HinhAnh = sp.Hinh_anh,
                                     DonGiaMua = Convert.ToSingle(ct.DonGia),
                                     SoNguoiMua = ct.SoLuong.GetValueOrDefault(),
                                     ThanhTien = Convert.ToSingle(ct.DonGia * ct.SoLuong.GetValueOrDefault())  // Tính thành tiền
                                 }).ToList();

            // Tính tổng tiền
            decimal tongTien = (decimal)chiTietHoaDon.Sum(item => item.ThanhTien);  // Sử dụng loại dữ liệu decimal

            // Truyền tổng tiền và chi tiết hóa đơn vào View
            ViewBag.TongTien = tongTien;
            ViewBag.HoaDon = hoaDon;

            // Truyền chi tiết hóa đơn vào View
            return View(chiTietHoaDon);
        }



        public ActionResult Index()
        {
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Login");
            }
            return View(db.KHACH_HANG.ToList());
        }

        // GET: KHACH_HANG/Login
        public ActionResult Login()
        {
            // Kiểm tra nếu khách hàng đã đăng nhập
            if (Session["KhachHang"] != null)
            {
                // Nếu đã đăng nhập, chuyển hướng đến trang sản phẩm hoặc trang đơn hàng
                return RedirectToAction("Index", "NVT_TOURs");
            }

            return View();
        }

        // POST: KHACH_HANG/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Mat_khau)
        {
            // Kiểm tra thông tin tài khoản trong bảng KHACH_HANG
            var khachHang = db.KHACH_HANG.FirstOrDefault(k => k.Email == Email);
            if (khachHang != null)
            {
                if (khachHang.Mat_khau == Mat_khau) // Khách Hàng
                {
                    Session["KhachHang"] = khachHang;
                    return RedirectToAction("Index", "Home"); // Điều hướng cho Khách hàng
                }
                else
                {
                    ViewBag.ErrorMessage = "Mật khẩu không đúng!";
                    return View();
                }
            }
            else
            {
                // Kiểm tra thông tin nhân viên
                var nhanVien = db.NHAN_VIEN.FirstOrDefault(nv => nv.Username == Email && nv.Password == Mat_khau);
                if (nhanVien != null)
                {
                    Session["user"] = nhanVien; // Lưu thông tin nhân viên vào session
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" }); // Điều hướng cho Nhân viên (Admin)
                }
                else
                {
                    ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }
            }
        }



        // GET: KHACH_HANG/Logout
        // GET: KHACH_HANG/Logout
        public ActionResult Logout()
        {
            // Xóa session
            Session["KhachHang"] = null;

            // Chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login", "NVT_KHACH_HANG");
        }


        public ActionResult Register()
        {
            return View();
        }

        // POST: KHACH_HANG/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KHACH_HANG model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tài khoản đã tồn tại hay chưa
                var existingUser = db.KHACH_HANG.FirstOrDefault(x => x.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                    return View(model);
                }

                // Kiểm tra định dạng email hợp lệ
                if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(model.Email))
                {
                    ModelState.AddModelError("", "Email không hợp lệ!");
                    return View(model);
                }

                // Tạo mới khách hàng
                model.Ngay_sinh = model.Ngay_sinh ?? DateTime.Now; // Gán ngày sinh mặc định nếu null
                model.Ngay_tao = DateTime.Now;
                model.Trang_thai = 1; // Giả sử trạng thái khách hàng là 1 (hoạt động)

                db.KHACH_HANG.Add(model);
                db.SaveChanges();

                // Redirect đến trang đăng nhập
                return RedirectToAction("Login", "NVT_KHACH_HANG");
            }

            return View(model);
        }
    }
}