using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Controllers
{
    public class NVT_TOURsController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: NVT_TOURs
        public ActionResult Index()
        {
            var tOURs = db.TOURs.Include(t => t.LOAI_TOUR);
            return View(tOURs.ToList());
        }

        // GET: NVT_TOURs/Details/5
        public ActionResult Details(int? id)
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

        // GET: NVT_TOURs/Create
        public ActionResult Create()
        {
            ViewBag.Ma_loai = new SelectList(db.LOAI_TOUR, "ID", "Ma_loai");
            return View();
        }

        // POST: NVT_TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ma_Tour,Ten_tour,Mo_ta,Ma_loai,Gia_tour,So_nguoi,Thoi_gian,Diem_khoi_hanh,Diem_den,Hinh_anh,Trang_thai")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_loai = new SelectList(db.LOAI_TOUR, "ID", "Ma_loai", tOUR.Ma_loai);
            return View(tOUR);
        }

        // GET: NVT_TOURs/Edit/5
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
            ViewBag.Ma_loai = new SelectList(db.LOAI_TOUR, "ID", "Ma_loai", tOUR.Ma_loai);
            return View(tOUR);
        }

        // POST: NVT_TOURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ma_Tour,Ten_tour,Mo_ta,Ma_loai,Gia_tour,So_nguoi,Thoi_gian,Diem_khoi_hanh,Diem_den,Hinh_anh,Trang_thai")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_loai = new SelectList(db.LOAI_TOUR, "ID", "Ma_loai", tOUR.Ma_loai);
            return View(tOUR);
        }

        // GET: NVT_TOURs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: NVT_TOURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOUR tOUR = db.TOURs.Find(id);
            db.TOURs.Remove(tOUR);
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
