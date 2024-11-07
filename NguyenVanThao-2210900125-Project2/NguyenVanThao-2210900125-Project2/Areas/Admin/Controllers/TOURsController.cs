using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanThao_2210900125_Project2.Models;

namespace NguyenVanThao_2210900125_Project2.Areas.Admin.Controllers
{
    public class TOURsController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();

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
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    // Lưu file
                    string rootFolder = Server.MapPath("/Areas/Admin/Data/");
                    string pathImage = rootFolder + fileAnh.FileName;
                    fileAnh.SaveAs(pathImage);

                    // Lưu thuộc tính url HinhAnh
                    tOUR.Hinh_anh = "/Areas/Admin/Data/" + fileAnh.FileName;
                }

                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_Tour,Ten_tour,Mo_ta,Gia_tour,Thoi_gian,Diem_khoi_hanh,Diem_den,Trang_thai")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOUR);
        }

        // GET: Admin/TOURs/Delete/5
        public ActionResult Delete(int? id)
        {
            NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();
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
