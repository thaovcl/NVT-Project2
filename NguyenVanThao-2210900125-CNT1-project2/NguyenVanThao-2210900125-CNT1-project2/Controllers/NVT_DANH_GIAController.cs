using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenVanThao_2210900125_CNT1_project2.Models;

namespace NguyenVanThao_2210900125_CNT1_project2.Controllers
{
    public class NVT_DANH_GIAController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: NVT_DANH_GIA
        public ActionResult Index()
        {
            var dANH_GIA = db.DANH_GIA.Include(d => d.KHACH_HANG).Include(d => d.TOUR);
            return View(dANH_GIA.ToList());
        }

        // GET: NVT_DANH_GIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // GET: NVT_DANH_GIA/Create
        public ActionResult Create()
        {
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten");
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour");
            return View();
        }

        // POST: NVT_DANH_GIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_danh_gia,Ma_tour,Ma_KH,Noi_dung,Diem_so,Ngay_danh_gia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.DANH_GIA.Add(dANH_GIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dANH_GIA.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dANH_GIA.Ma_tour);
            return View(dANH_GIA);
        }

        // GET: NVT_DANH_GIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dANH_GIA.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dANH_GIA.Ma_tour);
            return View(dANH_GIA);
        }

        // POST: NVT_DANH_GIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_danh_gia,Ma_tour,Ma_KH,Noi_dung,Diem_so,Ngay_danh_gia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "Ma_KH", "Ho_ten", dANH_GIA.Ma_KH);
            ViewBag.Ma_tour = new SelectList(db.TOURs, "Ma_Tour", "Ten_tour", dANH_GIA.Ma_tour);
            return View(dANH_GIA);
        }

        // GET: NVT_DANH_GIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // POST: NVT_DANH_GIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            db.DANH_GIA.Remove(dANH_GIA);
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
