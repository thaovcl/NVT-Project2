using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Areas.Admin.Controllers
{
    public class HOA_DONController : Controller
    {
        private NguyenVanThao_K22CNT1_Project2Entities db = new NguyenVanThao_K22CNT1_Project2Entities();

        // GET: Admin/HOA_DON
        public ActionResult Index()
        {
            var hOA_DON = db.HOA_DON.Include(h => h.KHACH_HANG);
            return View(hOA_DON.ToList());
        }

        // GET: Admin/HOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // GET: Admin/HOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "ID", "Ho_ten");
            return View();
        }

        // POST: Admin/HOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ma_hoa_don,Ma_KH,Ho_ten,Email,Dien_thoai,Dia_chi,Ma_dat_tour,Ngay_thanh_toan,Tong_tien,Phuong_thuc,Trang_thai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.HOA_DON.Add(hOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "ID", "Ho_ten", hOA_DON.Ma_KH);
            return View(hOA_DON);
        }

        // GET: Admin/HOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "ID", "Ho_ten", hOA_DON.Ma_KH);
            return View(hOA_DON);
        }

        // POST: Admin/HOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ma_hoa_don,Ma_KH,Ho_ten,Email,Dien_thoai,Dia_chi,Ma_dat_tour,Ngay_thanh_toan,Tong_tien,Phuong_thuc,Trang_thai")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_KH = new SelectList(db.KHACH_HANG, "ID", "Ho_ten", hOA_DON.Ma_KH);
            return View(hOA_DON);
        }

        // GET: Admin/HOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // POST: Admin/HOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            db.HOA_DON.Remove(hOA_DON);
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
