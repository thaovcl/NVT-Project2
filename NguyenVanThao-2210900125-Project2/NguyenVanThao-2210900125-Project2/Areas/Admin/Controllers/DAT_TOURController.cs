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
    public class DAT_TOURController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();

        // GET: Admin/DAT_TOUR
        public ActionResult Index()
        {
            var dAT_TOUR = db.DAT_TOUR.Include(d => d.KHACH_HANG).Include(d => d.TOUR);
            return View(dAT_TOUR.ToList());
        }

        // GET: Admin/DAT_TOUR/Create
        public ActionResult Create()
        {
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten");
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour");
            return View();
        }

        // POST: Admin/DAT_TOUR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_dat_tour,Ma_tour,Ma_KH,So_luong,Ngay_dat,Trang_thai")] DAT_TOUR dAT_TOUR)
        {
            if (ModelState.IsValid)
            {
                db.DAT_TOUR.Add(dAT_TOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dAT_TOUR.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dAT_TOUR.Ma_tour);
            return View(dAT_TOUR);
        }

        // GET: Admin/DAT_TOUR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAT_TOUR dAT_TOUR = db.DAT_TOUR.Find(id);
            if (dAT_TOUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dAT_TOUR.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dAT_TOUR.Ma_tour);
            return View(dAT_TOUR);
        }

        // POST: Admin/DAT_TOUR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_dat_tour,Ma_tour,Ma_KH,So_luong,Ngay_dat,Trang_thai")] DAT_TOUR dAT_TOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dAT_TOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dAT_TOUR.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dAT_TOUR.Ma_tour);
            return View(dAT_TOUR);
        }

        // GET: Admin/DAT_TOUR/Delete/5
        public ActionResult Delete(int? id)
        {
            NguyenVanThao_K22CNT1_Project2Entities1 db = new NguyenVanThao_K22CNT1_Project2Entities1();
            var updateModel = db.DAT_TOUR.Find(id);
            db.DAT_TOUR.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("DanhSach");
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
