using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Areas.Admin.Controllers
{
    public class TOURsController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: Admin/TOURs
        public ActionResult Index()
        {
            return View(db.TOURs.ToList());
        }

        // GET: Admin/TOURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_Tour,Ten_tour,Mo_ta,Gia_tour,Thoi_gian,Diem_khoi_hanh,Diem_den,Trang_thai")] TOUR tOUR, HttpPostedFileBase fileAnh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu file ảnh được tải lên
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    // Kiểm tra định dạng ảnh
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(fileAnh.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("", "Chỉ cho phép tải lên các tệp hình ảnh.");
                        return View(tOUR);
                    }

                    // Lưu file ảnh
                    string rootFolder = Server.MapPath("~/Areas/Admin/Data/");
                    string pathImage = Path.Combine(rootFolder, fileAnh.FileName);
                    fileAnh.SaveAs(pathImage);

                    // Lưu thuộc tính url HinhAnh
                    tOUR.Hinh_anh = "/Areas/Admin/Data/" + fileAnh.FileName;
                }

                // Lưu thông tin tour vào cơ sở dữ liệu
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu không hợp lệ, trả lại form và hiển thị lỗi
            return View(tOUR);
        }



        // GET: Admin/TOURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: Admin/TOURs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TOUR tOUR, HttpPostedFileBase fileAnh)
        {
            if (ModelState.IsValid)
            {
                // Nếu có ảnh mới được tải lên, xử lý và lưu lại
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    // Kiểm tra định dạng ảnh
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(fileAnh.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("", "Chỉ cho phép tải lên các tệp hình ảnh.");
                        return View(tOUR);
                    }

                    // Xóa ảnh cũ nếu có
                    if (!string.IsNullOrEmpty(tOUR.Hinh_anh))
                    {
                        string oldImagePath = Server.MapPath(tOUR.Hinh_anh);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Lưu file ảnh mới
                    string rootFolder = Server.MapPath("~/Areas/Admin/Data/");
                    string pathImage = Path.Combine(rootFolder, fileAnh.FileName);
                    fileAnh.SaveAs(pathImage);

                    // Lưu lại đường dẫn ảnh mới
                    tOUR.Hinh_anh = "/Areas/Admin/Data/" + fileAnh.FileName;
                }

                // Cập nhật thông tin tour vào cơ sở dữ liệu
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOUR);
        }

        // GET: Admin/TOURs/Delete/5
        public ActionResult Delete(int? id)
        {
            NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();
            var updateModel = db.TOURs.Find(id);
            db.TOURs.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
